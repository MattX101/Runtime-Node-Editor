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

        protected override void CodeToExecute()
        {
            SingleConnectionInputPointer input = GetSingle(0);
            if (input && IsConnected(input)) input.connectedOutputPointer.node.Execute();
        }

        protected override void DataToGetAndSet()
        {
            char c = IsChar(PointerValue.GetChar(GetSingle(0)));

            outputs[0].GetComponent<CharOutputPointer>().value = c;
            Elements.SetInputField(Elements.InputFields[0], c.ToString());
        }

        private char IsChar(char c)
        {
            return Elements.Dropdowns[0].Context switch
            {
                0 => ToLower(c),
                1 => ToUpper(c),
                _ => ' ',
            };
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<CharOutputPointer>().Reset();
        }

        private char ToLower(char c) => char.ToLower(c);
        private char ToUpper(char c) => char.ToUpper(c);
    }
}