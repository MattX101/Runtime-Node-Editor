using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class CharFlatArrayOutputNode : Node
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

            foreach (char value in input.connectedOutputPointer.GetComponent<CharArrayOutputPointer>().values)
                Debug.Log(value);
        }
    }
}
