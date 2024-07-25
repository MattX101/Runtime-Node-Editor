using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class CharIsNode : Node
    {
        public readonly string[] checks =
        {
            "Lower",
            "Upper",
            "White Space",
            "Separator",
            "Number",
            "Digit",
            "Letter",
            "Letter/Digit",
            "Symbol"
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
                }
            }

            bool result = false;
            switch (Elements.Dropdowns[0].Context)
            {
                case 0:
                    result = IsLower(c);
                    break;
                case 1:
                    result = IsUpper(c);
                    break;
                case 2:
                    result = IsWhiteSpace(c);
                    break;
                case 3:
                    result = IsSeparator(c);
                    break;
                case 4:
                    result = IsNumber(c);
                    break;
                case 5:
                    result = IsDigit(c);
                    break;
                case 6:
                    result = IsLetter(c);
                    break;
                case 7:
                    result = IsLetterOrDigit(c);
                    break;
                case 8:
                    result = IsSymbol(c);
                    break;
                default:
                    break;
            }

            outputs[0].GetComponent<BoolOutputPointer>().value = result;
            Elements.SetBoolean(Elements.Buttons[0], result);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }

        private bool IsLower(char c) { return char.IsLower(c); }
        private bool IsUpper(char c) { return char.IsUpper(c); }
        private bool IsWhiteSpace(char c) { return char.IsWhiteSpace(c); }
        private bool IsSeparator(char c) { return char.IsSeparator(c); }
        private bool IsNumber(char c) { return char.IsNumber(c); }
        private bool IsDigit(char c) { return char.IsDigit(c); }
        private bool IsLetter(char c) { return char.IsLetter(c); }
        private bool IsLetterOrDigit(char c) { return char.IsLetterOrDigit(c); }
        private bool IsSymbol(char c) { return char.IsSymbol(c); }
    }
}