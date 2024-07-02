using RuntimeNodeEditor.Data;
using System.Collections.Generic;
using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer.Data;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class OutputPointer : Pointer
    {
        public List<InputPointer> connectedInputPointers;
        public List<NodeConnectionLine> Lines;

        public PointerData Data;

        public OutputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.None;
        }

        private void Awake()
        {
            Data = new PointerData();
        }

        private void Update()
        {
            UpdateLines();
        }

        public override void Reset()
        {
            connectedInputPointers.Clear();
        }

        public void DeleteConnections()
        {
            if (connectedInputPointers == null)
                return;

            for (int i = connectedInputPointers.Count - 1; i >= 0; i--)
                DeleteConnection(i);
        }

        private void DeleteConnection(int i)
        {
            Lines[i].DestroyLine();

            connectedInputPointers[i].hasConnection = false;
            connectedInputPointers[i].connectedOutputPointer = null;
            connectedInputPointers[i].node.MoveUp();

            connectedInputPointers.RemoveAt(i);
        }

        private void UpdateLines()
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