using RuntimeNodeEditor.Node.UI.Functions;
using RNE.Template.Node.Pointer;
using UnityEngine;
using TMPro;
using Utils.IO.Serialization;

namespace RNE.Template.Node
{
    public class Vector2InputNode : RuntimeNodeEditor.Node.Node
    {
        [SerializeField] private TMP_InputField _inputfieldA;
        [SerializeField] private TMP_InputField _inputfieldB;

        protected override void CodeToExecute()
        {
            Outputs[0].GetComponent<Vector2OutputPointer>().Value = Vector2.zero;

            if (_inputfieldA.text.Length != 0)
            {
                float x = InputFieldToFloat.Get(_inputfieldA.text);

                Outputs[1].GetComponent<FloatOutputPointer>().Value = x;
                Outputs[0].GetComponent<Vector2OutputPointer>().Value.x = x;
            }

            if (_inputfieldB.text.Length != 0)
            {
                float y = InputFieldToFloat.Get(_inputfieldB.text);

                Outputs[2].GetComponent<FloatOutputPointer>().Value = y;
                Outputs[0].GetComponent<Vector2OutputPointer>().Value.y = y;
            }
        }

        protected override void CodeToReset()
        {
            Outputs[0].GetComponent<Vector2OutputPointer>().Reset();
        }

        public override void OnSave(FileWriter writer)
        {
            writer.Write(_inputfieldA.text);
            writer.Write(_inputfieldB.text);
        }

        public override void OnLoad(FileReader reader)
        {
            _inputfieldA.text = reader.ReadString();
            _inputfieldB.text = reader.ReadString();
        }
    }
}
