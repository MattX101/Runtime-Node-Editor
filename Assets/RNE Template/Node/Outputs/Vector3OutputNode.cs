using RNE.Template.Node.Pointer.Value;
using Utils.IO.Serialization;
using UnityEngine;
using TMPro;

namespace RNE.Template.Node
{
    public class Vector3OutputNode : RuntimeNodeEditor.Node.Node
    {
        [SerializeField] private TMP_InputField _inputfieldA;
        [SerializeField] private TMP_InputField _inputfieldB;
        [SerializeField] private TMP_InputField _inputfieldC;

        protected override void CodeToExecute()
        {
            ExecuteInputConnection(0);

            ExecuteInputConnection(1);
            ExecuteInputConnection(2);
            ExecuteInputConnection(3);
            
            Vector3 v = PointerValue.GetVector3(Inputs[0]);

            PointerValue.GetFloat(Inputs[1], ref v.x);
            PointerValue.GetFloat(Inputs[2], ref v.y);
            PointerValue.GetFloat(Inputs[3], ref v.z);

            _inputfieldA.text = v.x.ToString();
            _inputfieldB.text = v.y.ToString();
            _inputfieldC.text = v.z.ToString();
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
