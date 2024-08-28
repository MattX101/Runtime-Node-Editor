using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatFlatArrayOutputNode : Node
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

            foreach (float value in input.connectedOutputPointer.GetComponent<FloatArrayOutputPointer>().values)
                Debug.Log(value);
        }
    }
}
