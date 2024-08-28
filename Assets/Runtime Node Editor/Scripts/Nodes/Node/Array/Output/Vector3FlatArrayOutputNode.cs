using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3FlatArrayOutputNode : Node
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

            foreach (Vector3 value in input.connectedOutputPointer.GetComponent<Vector3ArrayOutputPointer>().values)
                Debug.Log(value);
        }
    }
}
