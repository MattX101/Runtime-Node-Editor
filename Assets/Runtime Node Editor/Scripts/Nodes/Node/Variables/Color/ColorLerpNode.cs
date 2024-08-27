using RuntimeNodeEditor.Functions.UI.Component;
using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class ColorLerpNode : Node
    {
        public ImagePreview ImagePreview;

        protected override void CodeToExecute()
        {
            SingleConnectionInputPointer inputA = GetSingle(0);
            if (inputA && IsConnected(inputA)) inputA.connectedOutputPointer.node.Execute();
            SingleConnectionInputPointer inputB = GetSingle(1);
            if (inputB && IsConnected(inputB)) inputB.connectedOutputPointer.node.Execute();
            
            SingleConnectionInputPointer inputT = GetSingle(2);
            if (inputT && IsConnected(inputT)) inputT.connectedOutputPointer.node.Execute();
        }

        protected override void DataToGetAndSet()
        {
            outputs[0].GetComponent<ColorOutputPointer>().value = Color.Lerp(
                PointerValue.GetColor(GetSingle(0)),
                PointerValue.GetColor(GetSingle(1)),
                PointerValue.GetFloat(GetSingle(2))
                );
            ImagePreview.Image.color = outputs[0].GetComponent<ColorOutputPointer>().value;
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<ColorOutputPointer>().Reset();
        }
    }
}