using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntOutputNode : Node
    {
        protected override void CodeToExecute()
        {
            SingleConnectionInputPointer input = GetSingle(0);
            if (input && IsConnected(input)) input.connectedOutputPointer.node.Execute();
        }

        protected override void DataToGetAndSet()
        {
            Elements.SetInputField(Elements.InputFields[0], PointerValue.GetInt(GetSingle(0)).ToString());
        }
    }
}
