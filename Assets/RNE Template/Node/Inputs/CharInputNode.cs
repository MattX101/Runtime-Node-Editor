using RNE.Template.Node.Pointer;
using Utils.IO.Serialization;
using UnityEngine;
using TMPro;

namespace RNE.Template.Node
{
    public class CharInputNode : RuntimeNodeEditor.Node.Node
    {
        [SerializeField]
        private TMP_InputField _inputfield;

        protected override void CodeToExecute()
        {
            PointerAccess.GetChar(Outputs[0].Id).Value =
                _inputfield.text.Length != 0 ?
                _inputfield.text[0] : 
                ' ';
        }

        protected override void CodeToReset()
        {
            PointerAccess.GetChar(Outputs[0].Id).Reset();
        }

        public override void OnSave(FileWriter writer)
        {
            writer.Write(_inputfield.text);
        }

        public override void OnLoad(FileReader reader)
        {
            _inputfield.text = reader.ReadString();
        }
    }
}
