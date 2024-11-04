using RNE.Template.Node.Pointer;

namespace RNE.Template.Node
{
    public class BoolInputNode : RuntimeNodeEditor.Node.Node
    {
        protected override void CodeToExecute()
        {
            Outputs[0].GetComponent<BoolOutputPointer>().Value = Elements.Buttons[0].Toggled;
        }

        protected override void CodeToReset()
        {
            Outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }
    }
}
