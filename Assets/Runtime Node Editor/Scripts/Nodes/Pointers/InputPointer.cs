using RuntimeNodeEditor.Nodes.Line;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class InputPointer : Pointer
    {
        public OutputPointer ConnectedOutputPointer
        {
            get;
            private set;
        }

        internal ConnectionLine Line
        {
            get;
            private set;
        }

        internal bool HasConnection
        {
            get;
            private set;
        }

        public InputPointer(Node.Node node) : base(node) { }

        internal void SetLineToNull()
        {
            Line = null;
        }

        internal void SetConnection(OutputPointer output, ConnectionLine line)
        {
            ConnectedOutputPointer = output;
            HasConnection = true;

            Line = line;
        }

        internal void DeleteConnection()
        {
            if (Line == null)
                return;

            Line.DestroyLine();
            Line = null;

            HasConnection = false;

            ConnectedOutputPointer.RemoveConnection(this);
            ConnectedOutputPointer = null;

            Node.MoveUp();
        }
    }
}
