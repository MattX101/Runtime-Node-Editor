using RNE.Template.Node.Pointer.Value;
using RuntimeNodeEditor.Node.UIFunctions.Component;

namespace RNE.Template.Node
{
    public class ColorOutputNode : RuntimeNodeEditor.Node.Node
    {
        public ImagePreview ImagePreview;

        protected override void CodeToExecute()
        {
            ExecuteInputConnection(0);
        }

        protected override void DataToGetAndSet()
        {
            ImagePreview.Image.color = PointerValue.GetColor(inputs[0]);
        }
    }
}
