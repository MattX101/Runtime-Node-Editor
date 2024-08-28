using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatOutputNode : Node
    {
        protected override void CodeToExecute()
        {
            ExecuteConnection(0);
        }

        protected override void DataToGetAndSet()
        {
            Elements.SetInputField(Elements.InputFields[0], PointerValue.GetFloat(GetSingle(0)).ToString());
        }
    }
}
