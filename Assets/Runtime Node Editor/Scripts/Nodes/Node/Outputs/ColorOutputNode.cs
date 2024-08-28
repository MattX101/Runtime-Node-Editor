using RuntimeNodeEditor.Functions.UI.Component;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class ColorOutputNode : Node
    {
        public ImagePreview ImagePreview;

        protected override void CodeToExecute()
        {
            ExecuteConnection(0);
        }

        protected override void DataToGetAndSet()
        {
            ImagePreview.Image.color = PointerValue.GetColor(GetSingle(0));
        }
    }
}
