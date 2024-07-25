using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringContactNode : Node
    {
        public override void Execute()
        {
            string a = "";
            if (inputs[0].TryGetComponent(out SingleConnectionInputPointer inputA))
            {
                if (inputA.connectedOutputPointer)
                {
                    inputA.connectedOutputPointer.node.Execute();
                    a = PointerValue.GetString(inputA.connectedOutputPointer);
                }
            }

            string b = "";
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer inputB))
            {
                if (inputB.connectedOutputPointer)
                {
                    inputB.connectedOutputPointer.node.Execute();
                    b = PointerValue.GetString(inputB.connectedOutputPointer);
                }
            }

            string value = string.Concat(a, b);
            outputs[0].GetComponent<StringOutputPointer>().value = value;

            Elements.SetInputField(Elements.InputFields[0], a);
            Elements.SetInputField(Elements.InputFields[1], b);
            Elements.SetInputField(Elements.InputFields[2], value);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<StringOutputPointer>().Reset();
        }
    }
}