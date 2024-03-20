using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class FloatInputNode : Node
    {
        public float value = 0.0f;

        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Exectute()
        {
            outputs[0].data.floatValue = value;

            wasExecuted = true;
        }

        public override void Reset()
        {
            wasExecuted = false;

            outputs[0].data.floatValue = 0.0f;
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new FloatInputUI(), spawnPosition);
        }
    }
}
