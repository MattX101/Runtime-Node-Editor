using RNE.Template.Node.Pointer;
using RNE.Template.Node.Pointer.Value;
using Utils.IO.Serialization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RNE.Template.Node
{
    public class LogicGateNode : RuntimeNodeEditor.Node.Node
    {
        [SerializeField] 
        private TMP_Dropdown _dropdown;

        [Space]

        [SerializeField] private Toggle _toggleA;
        [SerializeField] private Toggle _toggleB;

        [SerializeField] private Toggle _out;

        public readonly string[] Gates =
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
            ExecuteInputConnection(0);
            ExecuteInputConnection(1);

            bool a = false;
            if (Inputs[0].ConnectedOutputPointer)
            {
                a = PointerValue.GetBool(Inputs[0]);
                _toggleA.isOn = a;
            }
            else
            {
                a = _toggleA.isOn;
            }

            bool b = false;
            if (Inputs[1].ConnectedOutputPointer)
            {
                b = PointerValue.GetBool(Inputs[1]);
                _toggleB.isOn = b;
            }
            else
            {
                b = _toggleB.isOn;
            }

            bool result = CalcualteGate(a, b);

            Outputs[0].GetComponent<BoolOutputPointer>().Value = result;
            _out.isOn = result;
        }

        private bool CalcualteGate(bool a, bool b)
        {
            return _dropdown.value switch
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
            Outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }

        private bool AND(bool a, bool b) => a && b;
        private bool OR(bool a, bool b) => a || b;
        private bool NAND(bool a, bool b) => !(a && b);
        private bool NOR(bool a, bool b) => !(a || b);
        private bool XOR(bool a, bool b) => a != b;
        private bool XNOR(bool a, bool b) => a == b;

        public void SetDropdownValue(int value)
        {
            _dropdown.value = value;
        }

        public override void OnSave(FileWriter writer)
        {
            writer.Write(_dropdown.value);

            writer.Write(_toggleA.isOn);
            writer.Write(_toggleB.isOn);

            writer.Write(_out.isOn);
        }

        public override void OnLoad(FileReader reader)
        {
            _dropdown.value = reader.ReadInt();

            _toggleA.isOn = reader.ReadBool();
            _toggleB.isOn = reader.ReadBool();

            _out.isOn = reader.ReadBool();
        }
    }
}
