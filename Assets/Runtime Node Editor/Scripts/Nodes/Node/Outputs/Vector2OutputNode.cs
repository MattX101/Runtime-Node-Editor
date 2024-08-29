using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2OutputNode : Node
    {
        protected override void CodeToExecute()
        {
            ExecuteConnection(0);

            ExecuteConnection(1);
            ExecuteConnection(2);
        }

        protected override void DataToGetAndSet()
        {
            Vector2 v = Vector2.zero;

            v = PointerValue.GetVector2(GetSingle(0));

            PointerValue.GetFloat(GetSingle(1), ref v.x);
            PointerValue.GetFloat(GetSingle(2), ref v.y);

            Elements.SetInputField(Elements.InputFields[0], v.x.ToString());
            Elements.SetInputField(Elements.InputFields[1], v.y.ToString());
        }
    }
}
