using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer.Data;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class InputPointer : Pointer
    {
        public OutputPointer connectedOutputPointer;

        public ConnectionLine line;

        public bool hasConnection = false;

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
