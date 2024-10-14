using RNE.Template.Node.Pointer.Value;

namespace RNE.Template.Node
{
    public class IntOutputNode : RuntimeNodeEditor.Node.Node.Node
    {
        protected override void CodeToExecute()
        {
            ExecuteInputConnection(0);
        }

        protected override void DataToGetAndSet()
        {
            Elements.SetInputField(Elements.InputFields[0], PointerValue.GetInt(inputs[0]).ToString());
        }
    }
}
