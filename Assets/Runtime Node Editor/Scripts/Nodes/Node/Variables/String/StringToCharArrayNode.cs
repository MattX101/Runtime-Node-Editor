using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringToCharArrayNode : Node
    {
        protected override void CodeToExecute()
        {
            if (!inputs[0].TryGetComponent(out SingleConnectionInputPointer valueInput))
                return;

            if (valueInput.connectedOutputPointer)
            {
                valueInput.connectedOutputPointer.node.Execute();
                outputs[0].GetComponent<CharArrayOutputPointer>().values = PointerValue.GetString(valueInput.connectedOutputPointer).ToCharArray();
            }
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<CharArrayOutputPointer>().Reset();
        }
    }
}