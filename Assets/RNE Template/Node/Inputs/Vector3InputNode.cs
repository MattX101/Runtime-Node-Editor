using RuntimeNodeEditor.Node.UI.Functions;
using RNE.Template.Node.Pointer;
using Utils.IO.Serialization;
using UnityEngine;
using TMPro;

namespace RNE.Template.Node
{
    public class Vector3InputNode : RuntimeNodeEditor.Node.Node
    {
        [SerializeField] private TMP_InputField _inputfieldA;
        [SerializeField] private TMP_InputField _inputfieldB;
        [SerializeField] private TMP_InputField _inputfieldC;

        protected override void CodeToExecute()
        {
            Outputs[0].GetComponent<Vector3OutputPointer>().Value = Vector3.zero;

            if (_inputfieldA.text.Length != 0)
            {
                float x = InputFieldToFloat.Get(_inputfieldA.text);

                Outputs[1].GetComponent<FloatOutputPointer>().Value = x;
                Outputs[0].GetComponent<Vector3OutputPointer>().Value.x = x;
            }

            if (_inputfieldB.text.Length != 0)
            {
                float y = InputFieldToFloat.Get(_inputfieldB.text);

                Outputs[2].GetComponent<FloatOutputPointer>().Value = y;
                Outputs[0].GetComponent<Vector3OutputPointer>().Value.y = y;
            }

            if (_inputfieldC.text.Length != 0)
            {
                float z = InputFieldToFloat.Get(_inputfieldC.text);

                Outputs[3].GetComponent<FloatOutputPointer>().Value = z;
                Outputs[0].GetComponent<Vector3OutputPointer>().Value.z = z;
            }
        }

        protected override void CodeToReset()
        {
            Outputs[0].GetComponent<Vector3OutputPointer>().Reset();
        }

        public override void OnSave(FileWriter writer)
        {
            writer.Write(_inputfieldA.text);
            writer.Write(_inputfieldB.text);
            writer.Write(_inputfieldC.text);
        }

        public override void OnLoad(FileReader reader)
        {
            _inputfieldA.text = reader.ReadString();
            _inputfieldB.text = reader.ReadString();
            _inputfieldC.text = reader.ReadString();
        }
    }
}
