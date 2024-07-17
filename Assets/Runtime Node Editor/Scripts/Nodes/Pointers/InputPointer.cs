using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer.Data;
using System.Collections.Generic;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class InputPointer : Pointer
    {
        public OutputPointer connectedOutputPointer;
        public List<OutputPointer> connectedOutputPointers = null;

        public NodeConnectionLine Line;

        public bool hasConnection, allowsMultipleConnection;

        public InputPointer(Node.Node node) : base(node)
        {
            valueType = ValueType.None;
        }

        public void SetConnection(OutputPointer outputPointer)
        {
            hasConnection = true;
            connectedOutputPointer = outputPointer;
        }

        public void SetMultiConnection(OutputPointer outputPointer)
        {
            hasConnection = true;
            connectedOutputPointers.Add(outputPointer);
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
