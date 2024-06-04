using RuntimeNodeEditor.Node.Pointer;

namespace RuntimeNodeEditor.Node
{
    public class Vector3OutputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddInputPointer(inputs[0]);
            AddInputPointer(inputs[1]);
            AddInputPointer(inputs[2]);
            AddInputPointer(inputs[3]);
        }

        public override void Exectute()
        {
            float x = 0;
            float y = 0;
            float z = 0;

            if (inputs[0].connectedOutputPointer != null)
            {
                inputs[0].connectedOutputPointer.node.Exectute();

                x = inputs[0].connectedOutputPointer.data.vector3Value.x;
                y = inputs[0].connectedOutputPointer.data.vector3Value.y;
                z = inputs[0].connectedOutputPointer.data.vector3Value.z;
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
            if (inputs[3].connectedOutputPointer != null)
            {
                inputs[3].connectedOutputPointer.node.Exectute();
                z = inputs[3].connectedOutputPointer.data.floatValue;
            }

            elements.SetInputField(
                elements.inputFields[0],
                x.ToString());
            elements.SetInputField(
                elements.inputFields[1],
                y.ToString());
            elements.SetInputField(
                elements.inputFields[2],
                z.ToString());

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
