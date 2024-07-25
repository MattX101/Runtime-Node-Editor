using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class CharToNode : Node
    {
        public readonly string[] checks =
        {
            "Lower",
            "Upper"
        };

        public override void Execute()
        {
            char c = ' ';
            if (inputs[0].TryGetComponent(out SingleConnectionInputPointer input))
            {
                if (input.connectedOutputPointer)
                {
                    input.connectedOutputPointer.node.Execute();
                    c = PointerValue.GetChar(input.connectedOutputPointer);

                    switch (Elements.Dropdowns[0].Context)
                    {
                        case 0:
                            c = ToLower(c);
                            break;
                        case 1:
                            c = ToUpper(c);
                            break;
                        default:
                            break;
                    }
                }
            }

            outputs[0].GetComponent<CharOutputPointer>().value = c;
            Elements.SetInputField(Elements.InputFields[0], c.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<CharOutputPointer>().Reset();
        }

        private char ToLower(char c) { return char.ToLower(c); }
        private char ToUpper(char c) { return char.ToUpper(c); }
    }
}