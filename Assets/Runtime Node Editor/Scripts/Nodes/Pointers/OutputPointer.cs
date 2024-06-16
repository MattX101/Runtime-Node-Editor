using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Node.Line;
using System.Collections.Generic;

namespace RuntimeNodeEditor.Node.Pointer
{
    public class OutputPointer : Pointer
    {
        public List<InputPointer> connectedInputPointers;
        public List<LineController> lines;

        public PointerData data;

        public OutputPointer(string name, Node node) : base(name, node)
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
            
            foreach (LineController line in lines)
                line.UpdateLinePositions();
        }
    }
}