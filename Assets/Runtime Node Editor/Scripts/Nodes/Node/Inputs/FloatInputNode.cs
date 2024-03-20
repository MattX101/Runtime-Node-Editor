using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class FloatInputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Exectute()
        {
            outputs[0].data.floatValue =
                nodeUI.inputFields[0].text.Length != 0
                ? float.Parse(nodeUI.inputFields[0].text)
                : 0.0f;

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
