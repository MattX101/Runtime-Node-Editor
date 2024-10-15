using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Node.Connection.Line;
using System.Collections.Generic;

namespace RuntimeNodeEditor.Node.Pointer
{
    public class OutputPointer : Pointer
    {
        internal List<InputPointer> ConnectedInputPointers
        {
            get;
            private set;
        }

        internal List<ConnectionLine> Lines
        {
            get;
            private set;
        }

        public OutputPointer(Node node) : base(node) { }

        private void Update()
        {
            if (Lines == null || Lines.Count == 0)
                return;

            if (!CanvasData.IsDragging && !CanvasData.IsPanning && !CanvasData.IsScrolling)
                return;

            foreach (ConnectionLine line in Lines)
                line.UpdateLinePositions();
        }

        protected virtual void ResetPointer() { }
        public void Reset()
        {
            ResetPointer();

            if (ConnectedInputPointers == null)
                return;

            ConnectedInputPointers.Clear();
        }

        internal void AddConnection(InputPointer input)
        {
            ConnectedInputPointers ??= new List<InputPointer>();
            ConnectedInputPointers.Add(input);
        }

        internal void RemoveConnection(InputPointer input)
        {
            ConnectedInputPointers.Remove(input);
        }

        internal void DeleteConnections()
        {
            if (ConnectedInputPointers == null)
                return;

            for (int i = ConnectedInputPointers.Count - 1; i >= 0; i--)
                ConnectedInputPointers[i].DeleteConnection();
        }

        internal void AddLine(ConnectionLine connectionLine)
        {
            Lines ??= new List<ConnectionLine>();
            Lines.Add(connectionLine);
        }

        internal void RemoveLine(ConnectionLine connectionLine)
        {
            Lines.Remove(connectionLine);
        }
    }
}