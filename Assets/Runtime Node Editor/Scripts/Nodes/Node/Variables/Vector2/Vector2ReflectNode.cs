using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2ReflectNode : Node
    {
        protected override void CodeToExecute()
        {
            SingleConnectionInputPointer inputA = GetSingle(0);
            if (inputA && IsConnected(inputA)) inputA.connectedOutputPointer.node.Execute();
            
            SingleConnectionInputPointer inputB = GetSingle(1);
            if (inputB && IsConnected(inputB)) inputB.connectedOutputPointer.node.Execute();
        }

        protected override void DataToGetAndSet()
        {
            outputs[0].GetComponent<Vector2OutputPointer>().value = Vector2.Reflect(
                PointerValue.GetVector2(GetSingle(0)), 
                PointerValue.GetVector2(GetSingle(1))
                );

            Elements.SetInputField(Elements.InputFields[0], outputs[0].GetComponent<Vector2OutputPointer>().value.x.ToString());
            Elements.SetInputField(Elements.InputFields[1], outputs[0].GetComponent<Vector2OutputPointer>().value.y.ToString());
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<Vector2OutputPointer>().value = Vector2.zero;
        }
    }
}