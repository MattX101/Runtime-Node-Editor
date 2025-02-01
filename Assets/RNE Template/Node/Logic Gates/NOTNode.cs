using RNE.Template.Node.Pointer;
using RNE.Template.Node.Pointer.Value;
using Utils.IO.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace RNE.Template.Node
{
    public class NOTNode : RuntimeNodeEditor.Node.Node
    {
        [SerializeField] private Toggle _in;
        [SerializeField] private Toggle _out;

        protected override void CodeToExecute()
        {
            ExecuteInputConnection(0);

            bool a = PointerValue.GetBool(Inputs[0]);
            Outputs[0].GetComponent<BoolOutputPointer>().Value = !a;

            _in.isOn = a;
            _out.isOn = !a;
        }

        protected override void CodeToReset()
        {
            Outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }

        public override void OnSave(FileWriter writer)
        {
            writer.Write(_in.isOn);
            writer.Write(_out.isOn);
        }

        public override void OnLoad(FileReader reader)
        {
            _in.isOn = reader.ReadBool();
            _out.isOn = reader.ReadBool();
        }
    }
}
