using RuntimeNodeEditor.Nodes.Line;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class SingleConnectionInputPointer : InputPointer
    {
        public OutputPointer connectedOutputPointer;
        private NodeConnectionLine line;
        public NodeConnectionLine Line => line;

        public bool hasConnection = false;

        public SingleConnectionInputPointer(Node.Node node) : base(node)
        {
            //
        }

        public void Destroy()
        {
            line = null;
        }

        public void SetConnection(OutputPointer outputPointer, NodeConnectionLine line)
        {
            hasConnection = true;
            connectedOutputPointer = outputPointer;

            this.line = line;
        }

        public void DeleteConnection()
        {
            if (line == null)
                return;

            line.DestroyLine();

            hasConnection = false;

            connectedOutputPointer.connectedInputPointers.Remove(this);
            connectedOutputPointer = null;

            node.MoveUp();
        }
    }
}
