using RNE.Template.Node.Pointer;

namespace RNE.Template.Node
{
    public class BoolInputNode : RuntimeNodeEditor.Node.Node.Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<BoolOutputPointer>().value = Elements.Buttons[0].Toggled;
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }
    }
}
