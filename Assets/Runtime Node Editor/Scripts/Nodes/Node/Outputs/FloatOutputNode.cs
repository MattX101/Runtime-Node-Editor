using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatOutputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddInputPointer(inputs[0]);
        }

        public override void Execute()
        {
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                elements.SetInputField(
                    elements.inputFields[0], 
                    inputs[0].connectedOutputPointer.data.floatValue.ToString());
            }

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
