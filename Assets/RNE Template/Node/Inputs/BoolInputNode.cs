using RNE.Template.Node.Pointer;
using Utils.IO.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace RNE.Template.Node
{
    public class BoolInputNode : RuntimeNodeEditor.Node.Node
    {
        [SerializeField]
        private Toggle _toggle;

        protected override void CodeToExecute()
        {
            PointerAccess.GetBool(Outputs[0].Id).Value = _toggle.isOn;
        }

        protected override void CodeToReset()
        {
            PointerAccess.GetBool(Outputs[0].Id).Reset();
        }

        public override void OnSave(FileWriter writer)
        {
            writer.Write(_toggle.isOn);
        }

        public override void OnLoad(FileReader reader)
        {
            _toggle.isOn = reader.ReadBool();
        }
    }
}
