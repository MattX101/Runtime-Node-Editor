using RuntimeNodeEditor.Functions.UI.Component;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class ColorOutputNode : Node
    {
        public ImagePreview ImagePreview;

        protected override void CodeToExecute()
        {
            SingleConnectionInputPointer input = GetSingle(0);
            if (input && IsConnected(input)) input.connectedOutputPointer.node.Execute();
        }

        protected override void DataToGetAndSet()
        {
            ImagePreview.Image.color = PointerValue.GetColor(GetSingle(0));
        }
    }
}
