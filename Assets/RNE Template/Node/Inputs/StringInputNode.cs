using RNE.Template.Node.Pointer;

namespace RNE.Template.Node
{
    public class StringInputNode : RuntimeNodeEditor.Node.Node.Node
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
