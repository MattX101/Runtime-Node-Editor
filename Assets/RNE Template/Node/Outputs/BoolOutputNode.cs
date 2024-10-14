using RNE.Template.Node.Pointer.Value;

namespace RNE.Template.Node
{
    public class BoolOutputNode : RuntimeNodeEditor.Node.Node.Node
    {
        protected override void CodeToExecute()
        {
            ExecuteInputConnection(0);
        }

        protected override void DataToGetAndSet()
        {
            Elements.SetBoolean(Elements.Buttons[0], PointerValue.GetBool(inputs[0]));
        }
    }
}
