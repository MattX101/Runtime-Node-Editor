using RuntimeNodeEditor.Nodes.Line;
using System.Collections.Generic;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class MultiConnectionInputPointer : InputPointer
    {
        public List<OutputPointer> connectedOutputPointers;
        private List<NodeConnectionLine> lines;
        public NodeConnectionLine[] Lines => lines.ToArray();

        public MultiConnectionInputPointer(Node.Node node) : base(node)
        {
            //
        }

        public void SetMultiConnection(OutputPointer outputPointer, NodeConnectionLine line)
        {
            AddConnection(outputPointer);
            AddLine(line);
        }

        private void AddConnection(OutputPointer outputPointer)
        {
            connectedOutputPointers ??= new List<OutputPointer>();
            connectedOutputPointers.Add(outputPointer);
        }

        private void AddLine(NodeConnectionLine line)
        {
            lines ??= new List<NodeConnectionLine>();
            lines.Add(line);
        }

        public void Remove(NodeConnectionLine line)
        {
            lines.Remove(line);
        }

        public void DeleteConnection(OutputPointer outputPointer, NodeConnectionLine line)
        {
            if (line == null)
                return;

            line.DestroyLine();

            outputPointer.connectedInputPointers.Remove(this);
            connectedOutputPointers.Remove(outputPointer);

            node.MoveUp();
        }

        public void DeleteConnections()
        {
            if (lines == null)
                return;

            for (int i = connectedOutputPointers.Count - 1; i >= 0 ; i--)
            {
                if (connectedOutputPointers[i] == null)
                    return;

                lines[i].DestroyLine();

                connectedOutputPointers[i].connectedInputPointers.Remove(this);
                connectedOutputPointers.Remove(connectedOutputPointers[i]);
            }

            node.MoveUp();
        }
    }
}
