using RuntimeNodeEditor.Node.Pointer;

namespace RuntimeNodeEditor.Node
{
    public class IntInputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Execute()
        {
            outputs[0].data.intValue =
                elements.inputFields[0].text.Length != 0 
                ? int.Parse(elements.inputFields[0].text) 
                : 0;

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].data.intValue = 0;
        }
    }
}
