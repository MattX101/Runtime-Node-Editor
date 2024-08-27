using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class NOTNode : Node
    {
        protected override void CodeToExecute()
        {
            SingleConnectionInputPointer input = GetSingle(0);
            if (input && IsConnected(input)) input.connectedOutputPointer.node.Execute();
        }

        protected override void DataToGetAndSet()
        {
            bool a = PointerValue.GetBool(GetSingle(0));

            outputs[0].GetComponent<BoolOutputPointer>().value = !a;

            Elements.SetBoolean(Elements.Buttons[0], a);
            Elements.SetBoolean(Elements.Buttons[1], !a);
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }
    }
}
