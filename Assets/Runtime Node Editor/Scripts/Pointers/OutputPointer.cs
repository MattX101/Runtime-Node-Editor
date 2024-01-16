using RuntimeNodeEditor.Canvas.Data;
using RuntimeNodeEditor.RuntimeNode.Line;
using System.Collections.Generic;

namespace RuntimeNodeEditor.RuntimeNode.Pointer
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
            if (connectedInputPointers != null)
            {
                for (int i = connectedInputPointers.Count - 1; i >= 0; i--)
                {
                    lines[i].DestroyLine();

                    connectedInputPointers[i].connectedOutputPointer = null;
                    connectedInputPointers.RemoveAt(i);
                }
            }
        }

        private void UpdateLines()
        {
            if (lines != null && lines.Count > 0)
                if ((!CanvasData.isPointing && CanvasData.canPoint && !CanvasData.canDrag) || CanvasData.isPanning || CanvasData.isScrolling)
                    foreach (LineController line in lines)
                        line.UpdateLinePositions();
        }
    }
}