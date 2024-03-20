using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class IntInputNode : Node
    {
        public int value = 0;

        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Exectute()
        {
            outputs[0].data.intValue = value;

            wasExecuted = true;
        }

        public override void Reset()
        {
            wasExecuted = false;

            outputs[0].data.intValue = 0;
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new IntInputUI(), spawnPosition);
        }
    }
}
