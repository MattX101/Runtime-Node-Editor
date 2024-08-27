using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3OutputNode : Node
    {
        protected override void CodeToExecute()
        {
            SingleConnectionInputPointer inputV = GetSingle(0);
            SingleConnectionInputPointer inputX = GetSingle(1);
            SingleConnectionInputPointer inputY = GetSingle(2);
            SingleConnectionInputPointer inputZ = GetSingle(3);

            if (inputV && IsConnected(inputV)) inputV.connectedOutputPointer.node.Execute();

            if (inputX && IsConnected(inputX)) inputX.connectedOutputPointer.node.Execute();
            if (inputY && IsConnected(inputY)) inputY.connectedOutputPointer.node.Execute();
            if (inputZ && IsConnected(inputZ)) inputZ.connectedOutputPointer.node.Execute();
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
