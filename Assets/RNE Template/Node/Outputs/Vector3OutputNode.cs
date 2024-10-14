using RNE.Template.Node.Pointer.Value;
using UnityEngine;

namespace RNE.Template.Node
{
    public class Vector3OutputNode : RuntimeNodeEditor.Node.Node.Node
    {
        protected override void CodeToExecute()
        {
            ExecuteInputConnection(0);

            ExecuteInputConnection(1);
            ExecuteInputConnection(2);
            ExecuteInputConnection(3);
        }

        protected override void DataToGetAndSet()
        {
            Vector3 v = Vector3.zero;

            v = PointerValue.GetVector3(inputs[0]);

            PointerValue.GetFloat(inputs[1], ref v.x);
            PointerValue.GetFloat(inputs[2], ref v.y);
            PointerValue.GetFloat(inputs[3], ref v.z);

            Elements.SetInputField(Elements.InputFields[0], v.x.ToString());
            Elements.SetInputField(Elements.InputFields[1], v.y.ToString());
            Elements.SetInputField(Elements.InputFields[2], v.z.ToString());
        }
    }
}
