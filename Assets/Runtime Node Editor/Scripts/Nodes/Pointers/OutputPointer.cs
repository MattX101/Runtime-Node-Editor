using RuntimeNodeEditor.Data;
using System.Collections.Generic;
using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer.Data;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class OutputPointer : Pointer
    {
        public List<InputPointer> connectedInputPointers;
        public List<ConnectionLine> lines;

        public PointerData data;

        public OutputPointer(string name, Node.Node node) : base(name, node)
        {
            valueType = ValueType.None;
        }

        private void Awake()
        {
            data = new PointerData();
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
            lines[i].DestroyLine();

            connectedInputPointers[i].hasConnection = false;
            connectedInputPointers[i].connectedOutputPointer = null;
            connectedInputPointers[i].node.MoveUp();

            connectedInputPointers.RemoveAt(i);
        }

        private void UpdateLines()
        {
            if (lines == null || lines.Count == 0)
                return;

            if (!CanvasData.isDraging && !CanvasData.isPanning && !CanvasData.isScrolling) 
                return;
            
            foreach (ConnectionLine line in lines)
                line.UpdateLinePositions();
        }
    }
}