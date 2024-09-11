using RuntimeNodeEditor.Nodes.Line;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class InputPointer : Pointer
    {
        private OutputPointer _connectedOutputPointer;
        public OutputPointer ConnectedOutputPointer => _connectedOutputPointer;
        
        private NodeConnectionLine _line;
        internal NodeConnectionLine Line => _line;

        private bool _hasConnection = false;
        internal bool HasConnection => _hasConnection;

        public InputPointer(Node.Node node) : base(node) { }

        internal void SetLineToNull() => _line = null;

        internal void SetConnection(OutputPointer output, NodeConnectionLine line)
        {
            _hasConnection = true;
            _connectedOutputPointer = output;

            _line = line;
        }

        internal void DeleteConnection()
        {
            if (_line == null)
                return;

            _line.DestroyLine();
            _line = null;

            _hasConnection = false;

            _connectedOutputPointer.RemoveConnection(this);
            _connectedOutputPointer = null;

            Node.MoveUp();
        }
    }
}
