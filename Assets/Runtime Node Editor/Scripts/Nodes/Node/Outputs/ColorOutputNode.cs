using RuntimeNodeEditor.Functions.UI.Component;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class ColorOutputNode : Node
    {
        public ImagePreview ImagePreview;

        public override void Execute()
        {
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                ImagePreview.Image.color = inputs[0].connectedOutputPointer.Data.ColorValue;
            }

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
