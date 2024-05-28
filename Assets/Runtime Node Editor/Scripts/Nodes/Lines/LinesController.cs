using RuntimeNodeEditor.UI.Canvas.Data;
using RuntimeNodeEditor.UI.Data;
using RuntimeNodeEditor.Node.Pointer;
using System.Collections.Generic;
using UnityEngine;
using RuntimeNodeEditor.Node.Component;

namespace RuntimeNodeEditor.Node.Line
{
    public class LinesController : MonoBehaviour
    {
        public Transform parent;

        [SerializeField] private Camera _camera;

        private Vector2 _mousePos;
        private RaycastHit2D _raycastHit2D;

        private LineController _currentLineData;
        private List<LineController> _droppedLines;

        private OutputPointer _currentOutput;

        [SerializeField] private Material _sourceMaterial;

        private void Awake()
        {
            _droppedLines = new List<LineController>();
        }

        private void Update()
        {
            if (!(CanvasData.canvasIsActive || UIData.tabOpened || UIData.windowOpened))
                return;

            _raycastHit2D = Physics2D.Raycast(_mousePos, Vector2.zero);

            _mousePos = Input.mousePosition;
            _mousePos = _camera.ScreenToWorldPoint(_mousePos);

            if (Input.GetMouseButtonDown(0))
                CreateLineOnClick();
            else if (Input.GetMouseButtonUp(0) && CanvasData.isPointing)
                DropLine();
            else if (_currentLineData != null)
                _currentLineData.UpdateDraggingLine(_mousePos);

            if (Input.GetMouseButtonDown(1))
                DeletePointerConnectionsOnClick();

            if (_droppedLines != null && _droppedLines.Count > 0)
                foreach (LineController line in _droppedLines)
                    line.UpdateWidth();
        }

        private void CreateLineOnClick()
        {
            if (!CanvasData.canPoint)
                return;

            if (_raycastHit2D.collider == null || _raycastHit2D.collider.TryGetComponent(out OutputPointer outputPointer) == false)
                return;

            CanvasData.isPointing = true;
            CanvasData.canPoint = false;

            CreateLine(outputPointer);
        }

        private void CreateLine(OutputPointer outputPointer)
        {
            _sourceMaterial.color = PointerColor.PickColor(outputPointer.valueType);

            _currentLineData = new LineController(parent, _sourceMaterial, new Vector3(_mousePos.x, _mousePos.y, 100.0f));
            _currentLineData.output = outputPointer;

            _currentOutput = outputPointer;

            if (outputPointer.lines == null)
                outputPointer.lines = new List<LineController>();
            outputPointer.lines.Add(_currentLineData);
        }

        private void DropLine()
        {
            if (!LineDropped())
                _currentLineData.DestroyLine();

            CanvasData.isPointing = false;
            CanvasData.canPoint = true;

            _currentLineData = null;
            _currentOutput = null;
        }

        private bool LineDropped()
        {
            if (_raycastHit2D.collider == null)
                return false;

            _raycastHit2D.collider.TryGetComponent<InputPointer>(out InputPointer inputPointer);

            if (inputPointer == null)
                return false;
            if (inputPointer.hasConnection || _currentOutput.valueType != inputPointer.valueType)
                return false;

            DropOnInputPointer(inputPointer);

            return true;
        }

        private void DropOnInputPointer(InputPointer inputPointer)
        {
            if (_currentOutput.connectedInputPointers == null)
                _currentOutput.connectedInputPointers = new List<InputPointer>();

            _currentLineData.input = inputPointer;
            _currentOutput.connectedInputPointers.Add(inputPointer);

            inputPointer.SetConnection(_currentOutput);
            inputPointer.line = _currentLineData;

            _droppedLines.Add(_currentLineData);

            _currentOutput.node.MoveUp();
        }

        private void DeletePointerConnectionsOnClick()
        {
            if (_raycastHit2D.collider == null || CanvasData.isPointing)
                return;

            if (_raycastHit2D.collider.TryGetComponent(out OutputPointer outputPointer))
                DeleteOutputConnections(outputPointer);
            else if (_raycastHit2D.collider.TryGetComponent(out InputPointer inputPointer))
                DeleteInputConnections(inputPointer);
        }

        private void DeleteOutputConnections(OutputPointer outputPointer)
        {
            foreach (LineController line in outputPointer.lines)
                _droppedLines.Remove(line);
            outputPointer.DeleteConnections();
        }
        private void DeleteInputConnections(InputPointer inputPointer)
        {
            _droppedLines.Remove(inputPointer.line);
            inputPointer.DeleteConnection();
        }

        public void Paste(Node copiedNode, Node newNode)
        {
            if (copiedNode.inputs.Count == 0)
                return;

            for (int i = 0; i < copiedNode.inputs.Count; i++)
            {
                if (copiedNode.inputs[i].connectedOutputPointer == null)
                    continue;

                InputPointer newInput = newNode.inputs[i];
                OutputPointer output = copiedNode.inputs[i].connectedOutputPointer;

                SetConnection(newInput, output);
            }

            _currentLineData = null;
        }

        public void Load(InputPointer input, OutputPointer output)
        {
            SetConnection(input, output);

            _currentLineData = null;
        }

        private void SetConnection(InputPointer input, OutputPointer output)
        {
            if (output.connectedInputPointers == null)
                output.connectedInputPointers = new List<InputPointer>();
            output.connectedInputPointers.Add(input);

            input.SetConnection(output);
            CreateLine(output);

            input.line = _currentLineData;
            _currentLineData.input = input;

            _droppedLines.Add(_currentLineData);
        }
    }
}
