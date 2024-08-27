using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2OutputNode : Node
    {
        protected override void CodeToExecute()
        {
            SingleConnectionInputPointer inputV = GetSingle(0);
            SingleConnectionInputPointer inputX = GetSingle(1);
            SingleConnectionInputPointer inputY = GetSingle(2);

            if (inputV && IsConnected(inputV)) inputV.connectedOutputPointer.node.Execute();

            if (inputX && IsConnected(inputX)) inputX.connectedOutputPointer.node.Execute();
            if (inputY && IsConnected(inputY)) inputY.connectedOutputPointer.node.Execute();
        }

        protected override void DataToGetAndSet()
        {
            Vector2 v = Vector2.zero;

            v = PointerValue.GetVector3(GetSingle(0));

            v.x = PointerValue.GetFloat(GetSingle(1));
            v.y = PointerValue.GetFloat(GetSingle(2));

            Elements.SetInputField(Elements.InputFields[0], v.x.ToString());
            Elements.SetInputField(Elements.InputFields[1], v.y.ToString());
        }
    }
}
