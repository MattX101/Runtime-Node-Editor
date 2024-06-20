using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringInputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Execute()
        {
            outputs[0].data.stringValue = elements.inputFields[0].text;

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].data.stringValue = "";
        }
    }
}
