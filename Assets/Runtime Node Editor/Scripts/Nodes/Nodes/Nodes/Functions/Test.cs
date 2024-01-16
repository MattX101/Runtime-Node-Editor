using RuntimeNodeEditor.RuntimeNode.Pointer;
using RuntimeNodeEditor.RuntimeNode.UI;
using UnityEngine;

namespace RuntimeNodeEditor.RuntimeNode
{
    public class Test : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddInputPointer(inputs[0]);
            AddInputPointer(inputs[1]);

            AddOutputPointer(outputs[0]);
        }

        public override void Exectute()
        {
            float value1 = 0;
            if (inputs[0].connectedOutputPointer != null)
            {
                inputs[0].connectedOutputPointer.node.Exectute();
                value1 = inputs[0].connectedOutputPointer.data.intValue;
            }

            float value2 = 0;
            if (inputs[1].connectedOutputPointer != null)
            {
                inputs[1].connectedOutputPointer.node.Exectute();
                value2 = inputs[1].connectedOutputPointer.data.intValue;
            }

            outputs[0].data.floatValue = value1 + value2;

            wasExecuted = true;
        }

        public override void Reset()
        {
            wasExecuted = false;

            outputs[0].data.floatValue = 0;
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new TestUI(), spawnPosition);
        }
    }
}
