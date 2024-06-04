using RuntimeNodeEditor.Functions.UI.Component;
using RuntimeNodeEditor.Node.Pointer;

namespace RuntimeNodeEditor.Node
{
    public class ColorOutputNode : Node
    {
        public ImagePreview imagePreview;

        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddInputPointer(inputs[0]);
        }

        public override void Exectute()
        {
            if (inputs[0].connectedOutputPointer != null)
            {
                inputs[0].connectedOutputPointer.node.Exectute();
                imagePreview.Image.color = inputs[0].connectedOutputPointer.data.colorValue;
            }

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
