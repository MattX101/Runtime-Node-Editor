using RuntimeNodeEditor.Node.Pointer;

namespace RuntimeNodeEditor.Node
{
    public class Vector2OutputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddInputPointer(inputs[0]);
            AddInputPointer(inputs[1]);
            AddInputPointer(inputs[2]);
        }

        public override void Exectute()
        {
            float x = 0;
            float y = 0;

            if (inputs[0].connectedOutputPointer != null)
            {
                inputs[0].connectedOutputPointer.node.Exectute();

                x = inputs[0].connectedOutputPointer.data.vector2Value.x;
                y = inputs[0].connectedOutputPointer.data.vector2Value.y;
            }

            if (inputs[1].connectedOutputPointer != null)
            {
                inputs[1].connectedOutputPointer.node.Exectute();
                x = inputs[1].connectedOutputPointer.data.floatValue;
            }
            if (inputs[2].connectedOutputPointer != null)
            {
                inputs[2].connectedOutputPointer.node.Exectute();
                y = inputs[2].connectedOutputPointer.data.floatValue;
            }

            elements.SetInputField(
                elements.inputFields[0], 
                x.ToString());
            elements.SetInputField(
                elements.inputFields[1], 
                y.ToString());

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
