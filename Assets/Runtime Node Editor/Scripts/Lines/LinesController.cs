using RuntimeNodeEditor.Canvas.Data;
using RuntimeNodeEditor.RuntimeNode.Pointer;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.RuntimeNode.Line
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

            if (_droppedLines != null)
                if (_droppedLines.Count > 0)
                    foreach (LineController line in _droppedLines)
                        line.UpdateWidth();
        }

        private void CreateLineOnClick()
        {
            if (_raycastHit2D.collider != null && CanvasData.canPoint && _raycastHit2D.collider.TryGetComponent<OutputPointer>(out OutputPointer outputPointer))
            {
                CanvasData.isPointing = true;
                CanvasData.canPoint = false;

                CreateLine(outputPointer);
            }
        }

        /*public void CreateLinesOnNodePaste(List<InputPointer> inputs)
        {
            foreach (InputPointer input in inputs)
            {
                OutputPointer outputPointer = input.connectedOutputPointer;
                if (outputPointer != null)
                {
                    outputPointer.connectedInputPointers.Add(input);
                    Vector3 startPos = outputPointer.transform.position;

                    CreateLine(outputPointer, startPos);
                    DropOnInputPointer(input);

                    CanvasData.isPointing = false;
                    CanvasData.canPoint = true;

                    _currentLineData = null;
                    _currentOutput = null;
                }
            }
        }*/

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
            if (_raycastHit2D.collider != null && _raycastHit2D.collider.TryGetComponent<InputPointer>(out InputPointer inputPointer))
                if (!inputPointer.hasConnection && _currentOutput.valueType == inputPointer.valueType)
                    DropOnInputPointer(inputPointer);
                else
                    _currentLineData.DestroyLine();
            else
                _currentLineData.DestroyLine();

            CanvasData.isPointing = false;
            CanvasData.canPoint = true;

            _currentLineData = null;
            _currentOutput = null;
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
        }

        private void DeletePointerConnectionsOnClick()
        {
            if (_raycastHit2D.collider != null && !CanvasData.isPointing)
            {
                if (_raycastHit2D.collider.TryGetComponent(out OutputPointer outputPointer))
                {
                    foreach (LineController line in outputPointer.lines)
                        _droppedLines.Remove(line);
                    outputPointer.DeleteConnections();
                }
                else if (_raycastHit2D.collider.TryGetComponent(out InputPointer inputPointer))
                {
                    _droppedLines.Remove(inputPointer.line);
                    inputPointer.DeleteConnection();
                }
            }
        }
    }
}
