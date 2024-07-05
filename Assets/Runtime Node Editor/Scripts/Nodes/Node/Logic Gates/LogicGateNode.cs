using RuntimeNodeEditor.Functions.UI.Component;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class LogicGateNode : Node
    {
        public readonly string[] gates =
        {
            "AND",
            "OR",
            "NAND",
            "NOR",
            "XOR",
            "XNOR",
        };

        public Dropdown dropdown = new Dropdown();

        public override void Execute()
        {
            bool a = false;
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                Elements.SetBoolean(Elements.Buttons[0], inputs[0].connectedOutputPointer.Data.BoolValue);
                a = inputs[0].connectedOutputPointer.Data.BoolValue;
            }

            bool b = false;
            if (inputs[1].connectedOutputPointer)
            {
                inputs[1].connectedOutputPointer.node.Execute();
                Elements.SetBoolean(Elements.Buttons[1], inputs[1].connectedOutputPointer.Data.BoolValue);
                b = inputs[1].connectedOutputPointer.Data.BoolValue;
            }

            bool result = false;
            switch (dropdown.Context)
            {
                case 0:
                    result = AND(a, b);
                    break;
                case 1:
                    result = OR(a, b);
                    break;
                case 2:
                    result = NAND(a, b);
                    break;
                case 3:
                    result = NOR(a, b);
                    break;
                case 4:
                    result = XOR(a, b);
                    break;
                case 5:
                    result = XNOR(a, b);
                    break;
                default:
                    break;
            }
            outputs[0].Data.BoolValue = result;

            Elements.SetBoolean(Elements.Buttons[2], outputs[0].Data.BoolValue);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].Data.BoolValue = false;
        }

        private bool AND(bool a, bool b)   { return a && b; }
        private bool OR(bool a, bool b)    { return a || b; }
        private bool NAND(bool a, bool b)  { return !(a && b); }
        private bool NOR(bool a, bool b)   { return !(a || b); }
        private bool XOR(bool a, bool b)   { return a != b; }
        private bool XNOR(bool a, bool b)  { return a == b; }
    }
}
