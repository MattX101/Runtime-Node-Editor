using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class BoolInputNode : Node
    {
        public bool value = false;

        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Exectute()
        {
            outputs[0].data.boolValue = value;

            wasExecuted = true;
        }

        public override void Reset()
        {
            wasExecuted = false;

            outputs[0].data.boolValue = false;
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new BoolInputUI(), spawnPosition);
        }
    }
}
