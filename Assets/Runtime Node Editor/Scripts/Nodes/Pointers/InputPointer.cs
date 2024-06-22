using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer.Data;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class InputPointer : Pointer
    {
        public OutputPointer connectedOutputPointer;

        public NodeConnectionLine Line;

        public bool hasConnection;

        public InputPointer(string name, Node.Node node) : base(name, node)
        {
            valueType = ValueType.None;
        }

        public void SetConnection(OutputPointer outputPointer)
        {
            hasConnection = true;
            connectedOutputPointer = outputPointer;
        }

        public void DeleteConnection()
        {
            if (Line == null)
                return;

            Line.DestroyLine();

            hasConnection = false;

            connectedOutputPointer.connectedInputPointers.Remove(this);
            connectedOutputPointer = null;

            node.MoveUp();
        }
    }
}
