using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringJoinNode : Node
    {
        public override void Execute()
        {
            if (!inputs[0].TryGetComponent(out SingleConnectionInputPointer arrayInput))
                return;

            string seperator = "";
            string value = "";

            if (arrayInput.connectedOutputPointer)
            {
                arrayInput.connectedOutputPointer.node.Execute();

                if (inputs[1].TryGetComponent(out SingleConnectionInputPointer seperatorInput))
                {
                    if (seperatorInput.connectedOutputPointer)
                    {
                        seperatorInput.connectedOutputPointer.node.Execute();
                        seperator = PointerValue.GetString(seperatorInput.connectedOutputPointer);
                    }
                }

                value = string.Join(
                    seperator,
                    arrayInput.connectedOutputPointer.GetComponent<StringArrayOutputPointer>().values
                    );
            }

            outputs[0].GetComponent<StringOutputPointer>().value = value;

            Elements.SetInputField(Elements.InputFields[0], value);
            Elements.SetInputField(Elements.InputFields[1], seperator);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<StringOutputPointer>().Reset();
        }
    }
}