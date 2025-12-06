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
            PointerAccess.GetVector3(Outputs[0].Id).Value = Vector3.zero;

            if (_inputfieldA.text.Length != 0)
            {
                float x = InputFieldToFloat.Get(_inputfieldA.text);

                PointerAccess.GetFloat(Outputs[1].Id).Value = x;
                PointerAccess.GetVector3(Outputs[0].Id).Value.x = x;
            }

            if (_inputfieldB.text.Length != 0)
            {
                float y = InputFieldToFloat.Get(_inputfieldB.text);

                PointerAccess.GetFloat(Outputs[2].Id).Value = y;
                PointerAccess.GetVector3(Outputs[0].Id).Value.y = y;
            }

            if (_inputfieldC.text.Length != 0)
            {
                float z = InputFieldToFloat.Get(_inputfieldC.text);

                PointerAccess.GetFloat(Outputs[3].Id).Value = z;
                PointerAccess.GetVector3(Outputs[0].Id).Value.z = z;
            }
        }

        protected override void CodeToReset()
        {
            PointerAccess.GetVector3(Outputs[0].Id).Reset();
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
