using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class BoolFlatArrayOutputNode : Node
    {
        protected override void CodeToExecute()
        {
            SingleConnectionInputPointer input = GetSingle(0);
            if (input && IsConnected(input))
                input.connectedOutputPointer.node.Execute();
        }

        protected override void DataToGetAndSet()
        {
            SingleConnectionInputPointer input = GetSingle(0);

            if (!IsValid(input))
                return;

            foreach (bool value in input.connectedOutputPointer.GetComponent<BoolArrayOutputPointer>().values)
                Debug.Log(value);
        }
    }
}
