using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class ColorInputNode : Node
    {
        public Color value = Color.black;

        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Exectute()
        {
            outputs[0].data.colorValue = value;

            wasExecuted = true;
        }

        public override void Reset()
        {
            wasExecuted = false;

            outputs[0].data.colorValue = Color.black;
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new (), spawnPosition);
        }
    }
}
