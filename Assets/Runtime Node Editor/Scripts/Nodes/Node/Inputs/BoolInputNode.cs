using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class BoolInputNode : Node
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
