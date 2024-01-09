using RuntimeNodeEditor.RuntimeNode.Line;

namespace RuntimeNodeEditor.RuntimeNode.Pointer
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
            connectedOutputPointer = outputPointer;
        }

        public void DeleteConnection()
        {
            if (line != null)
            {
                line.DestroyLine();

                connectedOutputPointer.connectedInputPointers.Remove(this);
                connectedOutputPointer = null;
            }
        }
    }
}