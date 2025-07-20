using RNE.Template.Node.Pointer.Value;
using Utils.IO.Serialization;
using UnityEngine;
using TMPro;

namespace RNE.Template.Node
{
    public class Vector2OutputNode : RuntimeNodeEditor.Node.Node
    {
        [SerializeField] private TMP_InputField _inputfieldA;
        [SerializeField] private TMP_InputField _inputfieldB;

        protected override void CodeToExecute()
        {
            ExecuteInputConnection(0);

            ExecuteInputConnection(1);
            ExecuteInputConnection(2);

            Vector2 v = PointerValue.GetVector2(Inputs[0]);

            PointerValue.GetFloat(Inputs[1], ref v.x);
            PointerValue.GetFloat(Inputs[2], ref v.y);

            _inputfieldA.text = v.x.ToString();
            _inputfieldB.text = v.y.ToString();
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
