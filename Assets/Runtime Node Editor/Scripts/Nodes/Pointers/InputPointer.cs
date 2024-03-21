using RuntimeNodeEditor.Node.Line;

namespace RuntimeNodeEditor.Node.Pointer
{
    public class InputPointer : Pointer
    {
        public OutputPointer connectedOutputPointer;

        public LineController line;

        public bool hasConnection = false;

        public InputPointer(string name, Node node) : base(name, node)
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
            if (line != null)
            {
                line.DestroyLine();

                hasConnection = false;

                connectedOutputPointer.connectedInputPointers.Remove(this);
                connectedOutputPointer = null;

                node.MoveUp();
            }
        }
    }
}
