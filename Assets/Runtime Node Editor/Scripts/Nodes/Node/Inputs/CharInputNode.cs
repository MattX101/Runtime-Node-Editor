using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class CharInputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Execute()
        {
            outputs[0].data.charValue =
                elements.inputFields[0].text.Length != 0 ?
                elements.inputFields[0].text[0] : 
                ' ';

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].data.charValue = ' ';
        }
    }
}
