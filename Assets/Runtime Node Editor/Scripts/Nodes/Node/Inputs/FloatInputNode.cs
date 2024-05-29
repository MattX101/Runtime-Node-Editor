using RuntimeNodeEditor.Node.Pointer;

namespace RuntimeNodeEditor.Node
{
    public class FloatInputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Exectute()
        {
            outputs[0].data.floatValue =
                nodeUI.elements.inputFields[0].text.Length != 0
                ? float.Parse(nodeUI.elements.inputFields[0].text)
                : 0.0f;

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].data.floatValue = 0.0f;
        }
    }
}
