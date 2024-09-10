using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Nodes.Pointer.Type;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace RuntimeNodeEditor.Nodes.Lines
{
    public class NodeConnectionLines : MonoBehaviour
    {
        public Transform parent;
        
        private Vector2 _mousePos;
        private RaycastHit2D _raycastHit2D;

        private NodeConnectionLine _currentConnectionLine;

        private OutputPointer _currentOutputPointer;
        
        [SerializeField] private Material sourceMaterial;

        private void Update()
        {
            if (UIData.TabOrWindowOpened)
                return;

            _raycastHit2D = Physics2D.Raycast(_mousePos, Vector2.zero);
            
            _mousePos = MouseController.MouseWorldPosition;

            if (UnityEngine.Input.GetMouseButtonDown(0))
                CreateLineOnClick();
            else if (UnityEngine.Input.GetMouseButtonUp(0) && CanvasData.IsPointing)
                DropLine();
            else
                _currentConnectionLine?.UpdateDraggingLine(_mousePos);

            if (UnityEngine.Input.GetMouseButtonDown(1))
                LinesData.DeletePointerConnectionsOnClick(_raycastHit2D);

            if (LinesData.NotNullOrEmpty) 
                return;
            
            foreach (NodeConnectionLine line in LinesData.DroppedLinesArray)
                line.UpdateWidth();
        }

        public void Reset()
        {
            _currentConnectionLine = null;
            _currentOutputPointer = null;

            for (int i = LinesData.DroppedLinesArray.Length - 1; i >= 0; i--)
                LinesData.DroppedLinesArray[i].DestroyLine();
        }

        private void CreateLineOnClick()
        {
            if (!CanvasData.CanPoint)
                return;

            if (!_raycastHit2D.collider || _raycastHit2D.collider.TryGetComponent(out OutputPointer outputPointer) == false)
                return;

            CanvasData.IsPointing = true;
            CanvasData.CanPoint = false;

            CreateLine(outputPointer);
        }

        private void CreateLine(OutputPointer outputPointer)
        {
            sourceMaterial.color = PointerColor.PickColor(outputPointer.valueType);

            _currentConnectionLine = new NodeConnectionLine(parent, sourceMaterial, new Vector3(_mousePos.x, _mousePos.y, 100.0f))
            {
                Output = outputPointer
            };

            _currentOutputPointer = outputPointer;

            outputPointer.Lines ??= new List<NodeConnectionLine>();
            outputPointer.Lines.Add(_currentConnectionLine);
        }

        private void DropLine()
        {
            if (!LineDropped())
                _currentConnectionLine.DestroyLine();

            CanvasData.IsPointing = false;
            CanvasData.CanPoint = true;

            _currentConnectionLine = null;
            _currentOutputPointer = null;
        }

        private bool LineDropped()
        {
            if (!_raycastHit2D.collider)
                return false;

            _raycastHit2D.collider.TryGetComponent(out InputPointer inputPointer);

            if (!inputPointer)
                return false;

            if (!PointerValue.CheckCompatibility(inputPointer.valueType, _currentOutputPointer.valueType))
                return false;
            if (!PointerTypeCompatibility.CheckCompatibility(inputPointer.pointerType, _currentOutputPointer.pointerType))
                return false;

            if (inputPointer.hasConnection)
                return false;

            DropOnInputPointer(inputPointer);

            LinesData.Add(_currentConnectionLine);
            _currentOutputPointer.node.MoveUp();

            return true;
        }

        private void DropOnInputPointer(InputPointer inputPointer)
        {
            SetConnectionInput(inputPointer);
            
            inputPointer.SetConnection(_currentOutputPointer, _currentConnectionLine);
            inputPointer.node.Reset();
        }

        private void SetConnectionInput(InputPointer inputPointer)
        {
            _currentOutputPointer.connectedInputPointers ??= new List<InputPointer>();
            _currentOutputPointer.connectedInputPointers.Add(inputPointer);

            _currentConnectionLine.Input = inputPointer;
        }

        public void Paste(Node.Node copiedNode, Node.Node newNode)
        {
            if (copiedNode.inputs.Count == 0)
                return;

            for (int i = 0; i < copiedNode.inputs.Count; i++)
            {
                if (!copiedNode.inputs[i].connectedOutputPointer)
                    continue;

                SetConnection(newNode.inputs[i], copiedNode.inputs[i].connectedOutputPointer);
            }

            _currentConnectionLine = null;
        }

        public void Load(InputPointer input, OutputPointer output)
        {
            SetConnection(input, output);

            _currentConnectionLine = null;
        }

        private void SetConnection(InputPointer input, OutputPointer output)
        {
            output.connectedInputPointers ??= new List<InputPointer>();
            output.connectedInputPointers.Add(input);
            CreateLine(output);

            input.SetConnection(output, _currentConnectionLine);

            _currentConnectionLine.Input = input;
            LinesData.Add(_currentConnectionLine);
        }
        
        public void UpdateLinesOnLoad()
        {
            foreach (NodeConnectionLine line in LinesData.DroppedLinesArray)
            {
                line.UpdateLinePositionsOnLoad();
                line.UpdateWidth();
            }
        }
    }
}
