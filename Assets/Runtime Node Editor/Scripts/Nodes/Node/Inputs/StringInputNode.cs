using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringInputNode : Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<StringOutputPointer>().value = Elements.InputFields[0].text;
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<StringOutputPointer>().Reset();
        }
    }
}
