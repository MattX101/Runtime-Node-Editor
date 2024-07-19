namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class SingleConnectionInputPointer : InputPointer
    {
        public OutputPointer connectedOutputPointer;

        public bool hasConnection = false;

        public SingleConnectionInputPointer(Node.Node node) : base(node)
        {
            //
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
