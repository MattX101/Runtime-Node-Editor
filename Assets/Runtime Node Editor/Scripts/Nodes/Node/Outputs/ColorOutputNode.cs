using RuntimeNodeEditor.Functions.UI.Component;
using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class ColorOutputNode : Node
    {
        public ImagePreview imagePreview;

        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddInputPointer(inputs[0]);
        }

        public override void Execute()
        {
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
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
