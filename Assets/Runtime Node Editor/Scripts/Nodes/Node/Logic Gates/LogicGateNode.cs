using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

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

        protected override void CodeToExecute()
        {
            ExecuteConnection(0);
            ExecuteConnection(1);
        }

        protected override void DataToGetAndSet()
        {
            bool a = PointerValue.GetBool(GetSingle(0));
            bool b = PointerValue.GetBool(GetSingle(1));

            Elements.SetBoolean(Elements.Buttons[0], a);
            Elements.SetBoolean(Elements.Buttons[1], b);

            bool result = CalcualteGate(a, b);

            outputs[0].GetComponent<BoolOutputPointer>().value = result;
            Elements.SetBoolean(Elements.Buttons[2], result);
        }

        private bool CalcualteGate(bool a, bool b)
        {
            return Elements.Dropdowns[0].Context switch
            {
                0 => AND(a, b),
                1 => OR(a, b),
                2 => NAND(a, b),
                3 => NOR(a, b),
                4 => XOR(a, b),
                5 => XNOR(a, b),
                _ => false
            };
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }

        private bool AND(bool a, bool b) => a && b;
        private bool OR(bool a, bool b) => a || b;
        private bool NAND(bool a, bool b) => !(a && b);
        private bool NOR(bool a, bool b) => !(a || b);
        private bool XOR(bool a, bool b) => a != b;
        private bool XNOR(bool a, bool b) => a == b;
    }
}
