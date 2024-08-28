using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntFlatArrayOutputNode : Node
    {
        protected override void CodeToExecute()
        {
            ExecuteConnection(0);
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
