using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Nodes.Pointer;
using System.Collections.Generic;
using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Lines
{
    public class NodeConnectionLines : MonoBehaviour
    {
        public Transform parent;
        
        private Vector2 _mousePos;
        private RaycastHit2D _raycastHit2D;

        private NodeConnectionLine _currentConnectionLine;
        private List<NodeConnectionLine> _droppedLines;

        private OutputPointer _currentOutputPointer;
        
        [SerializeField] private Material sourceMaterial;

        private void Awake()
        {
            _droppedLines = new List<NodeConnectionLine>();
        }

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
                DeletePointerConnectionsOnClick();

            if (_droppedLines is not { Count: > 0 }) 
                return;
            
            foreach (NodeConnectionLine line in _droppedLines)
                line.UpdateWidth();
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
            if (inputPointer.hasConnection || _currentOutputPointer.valueType != inputPointer.valueType)
                return false;

            DropOnInputPointer(inputPointer);

            return true;
        }

        private void DropOnInputPointer(InputPointer inputPointer)
        {
            _currentOutputPointer.connectedInputPointers ??= new List<InputPointer>();

            _currentConnectionLine.Input = inputPointer;
            _currentOutputPointer.connectedInputPointers.Add(inputPointer);

            inputPointer.SetConnection(_currentOutputPointer);
            inputPointer.Line = _currentConnectionLine;

            _droppedLines.Add(_currentConnectionLine);

            _currentOutputPointer.node.MoveUp();
        }

        private void DeletePointerConnectionsOnClick()
        {
            if (!_raycastHit2D.collider || CanvasData.IsPointing)
                return;

            if (_raycastHit2D.collider.TryGetComponent(out OutputPointer outputPointer))
                DeleteOutputConnections(outputPointer);
            else if (_raycastHit2D.collider.TryGetComponent(out InputPointer inputPointer))
                DeleteInputConnections(inputPointer);
        }

        private void DeleteOutputConnections(OutputPointer outputPointer)
        {
            foreach (NodeConnectionLine line in outputPointer.Lines)
                _droppedLines.Remove(line);
            outputPointer.DeleteConnections();
        }
        private void DeleteInputConnections(InputPointer inputPointer)
        {
            _droppedLines.Remove(inputPointer.Line);
            inputPointer.DeleteConnection();
        }

        public void Paste(Node.Node copiedNode, Node.Node newNode)
        {
            if (copiedNode.inputs.Count == 0)
                return;

            for (int i = 0; i < copiedNode.inputs.Count; i++)
            {
                if (!copiedNode.inputs[i].connectedOutputPointer)
                    continue;

                InputPointer newInput = newNode.inputs[i];
                OutputPointer output = copiedNode.inputs[i].connectedOutputPointer;

                SetConnection(newInput, output);
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

            input.SetConnection(output);
            CreateLine(output);

            input.Line = _currentConnectionLine;
            _currentConnectionLine.Input = input;

            _droppedLines.Add(_currentConnectionLine);
        }
    }
}
