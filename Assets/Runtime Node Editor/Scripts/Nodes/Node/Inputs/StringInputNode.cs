using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringInputNode : Node
    {
        public override void Execute()
        {
            outputs[0].GetComponent<StringOutputPointer>().value = Elements.InputFields[0].text;

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<StringOutputPointer>().Reset();
        }
    }
}
