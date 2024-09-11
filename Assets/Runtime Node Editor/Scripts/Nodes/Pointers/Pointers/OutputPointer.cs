using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Nodes.Line;
using System.Collections.Generic;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class OutputPointer : Pointer
    {
        private List<InputPointer> _connectedInputPointers;
        internal List<InputPointer> ConnectedInputPointers => _connectedInputPointers;

        private List<NodeConnectionLine> _lines;
        internal List<NodeConnectionLine> Lines => _lines;

        public OutputPointer(Node.Node node) : base(node) { }

        private void Update()
        {
            if (_lines == null || _lines.Count == 0)
                return;

            if (!CanvasData.IsDragging && !CanvasData.IsPanning && !CanvasData.IsScrolling)
                return;

            foreach (NodeConnectionLine line in _lines)
                line.UpdateLinePositions();
        }

        private protected virtual void ResetPointer() { }
        internal void Reset()
        {
            ResetPointer();

            if (_connectedInputPointers == null)
                return;

            _connectedInputPointers.Clear();
        }

        internal void AddConnection(InputPointer input)
        {
            _connectedInputPointers ??= new List<InputPointer>();
            _connectedInputPointers.Add(input);
        }

        internal void RemoveConnection(InputPointer input)
        {
            _connectedInputPointers.Remove(input);
        }

        internal void DeleteConnections()
        {
            if (_connectedInputPointers == null)
                return;

            for (int i = _connectedInputPointers.Count - 1; i >= 0; i--)
                _connectedInputPointers[i].DeleteConnection();
        }

        internal void AddLine(NodeConnectionLine connectionLine)
        {
            _lines ??= new List<NodeConnectionLine>();
            _lines.Add(connectionLine);
        }

        internal void RemoveLine(NodeConnectionLine connectionLine)
        {
            _lines.Remove(connectionLine);
        }
    }
}