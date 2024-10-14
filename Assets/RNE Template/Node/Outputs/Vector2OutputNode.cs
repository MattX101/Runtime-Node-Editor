using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2OutputNode : Node
    {
        protected override void CodeToExecute()
        {
            ExecuteInputConnection(0);

            ExecuteInputConnection(1);
            ExecuteInputConnection(2);
        }

        protected override void DataToGetAndSet()
        {
            Vector2 v = Vector2.zero;

            v = PointerValue.GetVector2(inputs[0]);

            PointerValue.GetFloat(inputs[1], ref v.x);
            PointerValue.GetFloat(inputs[2], ref v.y);

            Elements.SetInputField(Elements.InputFields[0], v.x.ToString());
            Elements.SetInputField(Elements.InputFields[1], v.y.ToString());
        }
    }
}
