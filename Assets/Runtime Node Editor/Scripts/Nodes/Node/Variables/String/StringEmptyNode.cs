using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringEmptyNode : Node
    {
        public override void Execute()
        {
            outputs[0].GetComponent<StringOutputPointer>().value = string.Empty;
            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}