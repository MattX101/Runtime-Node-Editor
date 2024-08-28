using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class ColorFlatArrayOutputNode : Node
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

            foreach (Color value in input.connectedOutputPointer.GetComponent<ColorArrayOutputPointer>().values)
                Debug.Log(value);
        }
    }
}
