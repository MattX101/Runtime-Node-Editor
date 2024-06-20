using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class BoolInputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Execute()
        {
            outputs[0].data.boolValue = elements.buttons[0].Toggled;

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].data.boolValue = false;
        }
    }
}
