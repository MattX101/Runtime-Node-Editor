using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Lines
{
    public class NodeConnectionLines : MonoBehaviour
    {
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
                UpdateLineWidth(line);
        }

        public void Reset()
        {
            _currentConnectionLine = null;
            _currentOutputPointer = null;

            for (int i = LinesData.DroppedLinesArray.Length - 1; i >= 0; i--)
                DestroyLine(LinesData.DroppedLinesArray[i]);
        }

        private void DestroyLine(NodeConnectionLine line)
        {
            line.DestroyLine();
        }

        private void CreateLineOnClick()
        {
            if (!CanvasData.CanPoint)
                return;

            if (!_raycastHit2D.collider || _raycastHit2D.collider.TryGetComponent(out OutputPointer output) == false)
                return;

            CanvasData.IsPointing = true;
            CanvasData.CanPoint = false;

            CreateLine(output);
        }

        private void CreateLine(OutputPointer output)
        {
            sourceMaterial.color = PointerColor.PickColor(output.ValueType);

            _currentConnectionLine = new NodeConnectionLine(sourceMaterial, new Vector3(_mousePos.x, _mousePos.y, 100.0f))
            {
                Output = output
            };

            _currentOutputPointer = output;

            output.AddLine(_currentConnectionLine);
        }

        private void DropLine()
        {
            if (!LineDropped())
                DestroyLine(_currentConnectionLine);

            CanvasData.IsPointing = false;
            CanvasData.CanPoint = true;

            _currentConnectionLine = null;
            _currentOutputPointer = null;
        }

        private void UpdateLineWidth(NodeConnectionLine line)
        {
            line.UpdateWidth();
        }

        private bool LineDropped()
        {
            if (!_raycastHit2D.collider)
                return false;

            _raycastHit2D.collider.TryGetComponent(out InputPointer input);

            if (!input)
                return false;

            if (!PointerValue.CheckCompatibility(input.ValueType, _currentOutputPointer.ValueType))
                return false;

            if (input.HasConnection)
                return false;

            DropOnInputPointer(input);

            LinesData.Add(_currentConnectionLine);
            _currentOutputPointer.Node.MoveUp();

            return true;
        }

        private void DropOnInputPointer(InputPointer input)
        {
            _currentOutputPointer.AddConnection(input);
            _currentConnectionLine.Input = input;

            SetInputConnection(input, _currentOutputPointer, _currentConnectionLine);
            input.Node.Reset();
        }

        private void SetInputConnection(InputPointer input, OutputPointer output, NodeConnectionLine line)
        {
            input.SetConnection(output, line);
        }

        public void Paste(Node.Node copiedNode, Node.Node newNode)
        {
            if (copiedNode.inputs.Count == 0)
                return;

            for (int i = 0; i < copiedNode.inputs.Count; i++)
            {
                if (!copiedNode.inputs[i].ConnectedOutputPointer)
                    continue;

                SetConnection(newNode.inputs[i], copiedNode.inputs[i].ConnectedOutputPointer);
            }

            _currentConnectionLine = null;
        }

        private void SetConnection(InputPointer input, OutputPointer output)
        {
            output.AddConnection(input);
            CreateLine(output);

            SetInputConnection(input, output, _currentConnectionLine);

            _currentConnectionLine.Input = input;
            LinesData.Add(_currentConnectionLine);
        }

        public void Load(InputPointer input, OutputPointer output)
        {
            SetConnection(input, output);

            _currentConnectionLine = null;
        }
        
        public void UpdateLinesOnLoad()
        {
            foreach (NodeConnectionLine line in LinesData.DroppedLinesArray)
            {
                line.UpdateLinePositionsOnLoad();
                UpdateLineWidth(line);
            }
        }
    }
}
