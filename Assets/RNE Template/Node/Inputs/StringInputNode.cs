using RNE.Template.Node.Pointer;

namespace RNE.Template.Node
{
    public class StringInputNode : RuntimeNodeEditor.Node.Node
    {
        protected override void CodeToExecute()
        {
            Outputs[0].GetComponent<StringOutputPointer>().Value = Elements.InputFields[0].text;
        }

        protected override void CodeToReset()
        {
            Outputs[0].GetComponent<StringOutputPointer>().Reset();
        }
    }
}
