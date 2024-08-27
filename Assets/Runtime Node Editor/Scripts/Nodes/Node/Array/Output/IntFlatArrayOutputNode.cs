using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntFlatArrayOutputNode : Node
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

            foreach (int value in input.connectedOutputPointer.GetComponent<IntArrayOutputPointer>().values)
                Debug.Log(value);
        }
    }
}
