using RuntimeNodeEditor.RuntimeNode.Pointer;
using RuntimeNodeEditor.RuntimeNode.UI;
using UnityEngine;

namespace RuntimeNodeEditor.RuntimeNode
{
    public class ImportNode : Node
    {
        public int value = 1;

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
            return Paste(new ImportUI(), spawnPosition);
        }
    }
}
