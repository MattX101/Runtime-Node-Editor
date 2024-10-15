namespace RuntimeNodeEditor.Node.Connection.Lines
{
    public partial class ConnectionLines
    {
        public void Paste(Node copiedNode, Node newNode)
        {
            if (copiedNode.inputs.Count == 0)
                return;

            for (int i = 0; i < copiedNode.inputs.Count; i++)
            {
                if (!copiedNode.inputs[i].ConnectedOutputPointer)
                    continue;

                SetConnection(newNode.inputs[i], copiedNode.inputs[i].ConnectedOutputPointer);
            }

            _currentConnectionLine = null;
        }
    }
}
