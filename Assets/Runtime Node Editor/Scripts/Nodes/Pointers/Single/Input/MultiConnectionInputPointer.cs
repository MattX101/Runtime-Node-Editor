using System.Collections.Generic;

namespace RuntimeNodeEditor.Nodes.Pointer
{
    public class MultiConnectionInputPointer : InputPointer
    {
        public List<OutputPointer> connectedOutputPointers = null;

        public MultiConnectionInputPointer(Node.Node node) : base(node)
        {
            //
        }

        public void SetMultiConnection(OutputPointer outputPointer)
        {
            connectedOutputPointers.Add(outputPointer);
        }

        // Delete Connections
    }
}
