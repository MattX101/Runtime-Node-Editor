using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using System.Collections.Generic;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class OutputPointer : Pointer
    {
        public List<InputPointer> connectedInputPointers;
        public List<NodeConnectionLine> Lines;

        public OutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.None;
        }

        private void Update()
        {
            UpdateLines();
        }

        public override void Reset()
        {
            if (connectedInputPointers == null)
                return;

            connectedInputPointers.Clear();
        }

        public void DeleteConnections()
        {
            if (connectedInputPointers == null)
                return;

            for (int i = connectedInputPointers.Count - 1; i >= 0; i--)
                DeleteConnection(i);
        }

        protected void DeleteConnection(int i)
        {
            if (connectedInputPointers[i].TryGetComponent(out SingleConnectionInputPointer single))
            {
                single.DeleteConnection();
            }
            else if (connectedInputPointers[i].TryGetComponent(out MultiConnectionInputPointer multi))
            {
                multi.DeleteConnection(this, Lines[i]);
            }
            else
            {
                return;
            }
        }

        protected void UpdateLines()
        {
            if (Lines == null || Lines.Count == 0)
                return;

            if (!CanvasData.IsDragging && !CanvasData.IsPanning && !CanvasData.IsScrolling) 
                return;
            
            foreach (NodeConnectionLine line in Lines)
                line.UpdateLinePositions();
        }
    }
}