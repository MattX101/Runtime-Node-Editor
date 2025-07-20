using RNE.Template.Node.Pointer.Value;
using Utils.IO.Serialization;
using UnityEngine;
using TMPro;

namespace RNE.Template.Node
{
    public class IntOutputNode : RuntimeNodeEditor.Node.Node
    {
        [SerializeField]
        private TMP_InputField _inputfield;

        protected override void CodeToExecute()
        {
            ExecuteInputConnection(0);
            _inputfield.text = PointerValue.GetInt(Inputs[0]).ToString();
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
