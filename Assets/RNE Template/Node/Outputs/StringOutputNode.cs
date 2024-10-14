using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringOutputNode : Node
    {
        protected override void CodeToExecute()
        {
            ExecuteInputConnection(0);
        }

        protected override void DataToGetAndSet()
        {
            Elements.SetInputField(Elements.InputFields[0], PointerValue.GetString(inputs[0]));
        }
    }
}
