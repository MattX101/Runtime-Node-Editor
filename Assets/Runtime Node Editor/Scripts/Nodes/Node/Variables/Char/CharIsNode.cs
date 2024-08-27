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

        protected override void CodeToExecute()
        {
            SingleConnectionInputPointer input = GetSingle(0);
            if (input && IsConnected(input)) input.connectedOutputPointer.node.Execute();
        }

        protected override void DataToGetAndSet()
        {
            bool result = IsChar(PointerValue.GetChar(GetSingle(0)));

            outputs[0].GetComponent<BoolOutputPointer>().value = result;
            Elements.SetBoolean(Elements.Buttons[0], result);
        }

        private bool IsChar(char c)
        {
            return Elements.Dropdowns[0].Context switch
            {
                0 => IsLower(c),
                1 => IsUpper(c),
                2 => IsWhiteSpace(c),
                3 => IsSeparator(c),
                4 => IsNumber(c),
                5 => IsDigit(c),
                6 => IsLetter(c),
                7 => IsLetterOrDigit(c),
                8 => IsSymbol(c),
                _ => false,
            };
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }

        private bool IsLower(char c) => char.IsLower(c);
        private bool IsUpper(char c) => char.IsUpper(c);
        private bool IsWhiteSpace(char c) => char.IsWhiteSpace(c);
        private bool IsSeparator(char c) => char.IsSeparator(c);
        private bool IsNumber(char c) => char.IsNumber(c);
        private bool IsDigit(char c) => char.IsDigit(c);
        private bool IsLetter(char c) => char.IsLetter(c);
        private bool IsLetterOrDigit(char c) => char.IsLetterOrDigit(c);
        private bool IsSymbol(char c) => char.IsSymbol(c);
    }
}