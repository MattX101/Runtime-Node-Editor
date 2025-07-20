using RuntimeNodeEditor.Node.Connection.Line;

namespace RuntimeNodeEditor.Node.Pointer
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

        private void Awake()
        {
            ValueTypeIndex = 1;
        }

        public virtual void DisableUIElement()
        {
            //
        }

        public virtual void EnableUIElement()
        {
            //
        }

        internal void SetLineToNull()
        {
            Line = null;
        }

        internal void SetConnection(OutputPointer Output, ConnectionLine line)
        {
            ConnectedOutputPointer = Output;
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

            Node.ResetAndExecute();
        }
    }
}
