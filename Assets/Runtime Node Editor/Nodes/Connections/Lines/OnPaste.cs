namespace RuntimeNodeEditor.Node.Connection.Lines
{
    public partial class ConnectionLines
    {
        public void Paste(Node copiedNode, Node newNode)
        {
            if (copiedNode.Inputs.Count == 0)
                return;

            for (int i = 0; i < copiedNode.Inputs.Count; i++)
            {
                if (!copiedNode.Inputs[i].ConnectedOutputPointer)
                    continue;

                SetConnection(newNode.Inputs[i], copiedNode.Inputs[i].ConnectedOutputPointer);
            }

            _currentConnectionLine = null;
        }
    }
}
