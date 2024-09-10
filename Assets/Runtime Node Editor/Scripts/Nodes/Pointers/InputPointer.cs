using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class InputPointer : Pointer
    {
        public OutputPointer connectedOutputPointer;
        private NodeConnectionLine line;
        public NodeConnectionLine Line => line;

        public bool hasConnection = false;

        public InputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.None;
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
