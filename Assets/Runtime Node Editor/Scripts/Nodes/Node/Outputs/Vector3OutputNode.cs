using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3OutputNode : Node
    {
        protected override void CodeToExecute()
        {
            ExecuteConnection(0);

            ExecuteConnection(1);
            ExecuteConnection(2);
            ExecuteConnection(3);
        }

        protected override void DataToGetAndSet()
        {
            Vector3 v = Vector3.zero;

            v = PointerValue.GetVector3(GetSingle(0));

            v.x = PointerValue.GetFloat(GetSingle(1));
            v.y = PointerValue.GetFloat(GetSingle(2));
            v.z = PointerValue.GetFloat(GetSingle(3));

            Elements.SetInputField(Elements.InputFields[0], v.x.ToString());
            Elements.SetInputField(Elements.InputFields[1], v.y.ToString());
            Elements.SetInputField(Elements.InputFields[2], v.z.ToString());
        }
    }
}
