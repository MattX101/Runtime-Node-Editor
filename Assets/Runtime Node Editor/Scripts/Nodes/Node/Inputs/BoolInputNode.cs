using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class BoolInputNode : Node
    {
        public override void Execute()
        {
            outputs[0].GetComponent<BoolOutputPointer>().value = Elements.Buttons[0].Toggled;

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }
    }
}
