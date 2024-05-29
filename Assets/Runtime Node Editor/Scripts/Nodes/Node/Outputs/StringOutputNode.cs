using RuntimeNodeEditor.Node.Pointer;

namespace RuntimeNodeEditor.Node
{
    public class StringOutputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddInputPointer(inputs[0]);
        }

        public override void Exectute()
        {
            if (inputs[0].connectedOutputPointer != null)
            {
                inputs[0].connectedOutputPointer.node.Exectute();
                nodeUI.elements.SetInputField(
                    nodeUI.elements.inputFields[0],
                    inputs[0].connectedOutputPointer.data.stringValue);
            }

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
