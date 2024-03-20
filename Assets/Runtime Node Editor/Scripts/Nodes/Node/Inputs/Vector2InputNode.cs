using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class Vector2InputNode : Node
    {
        public Vector2 value = Vector2.zero;

        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Exectute()
        {
            outputs[0].data.vector2Value = value;

            wasExecuted = true;
        }

        public override void Reset()
        {
            wasExecuted = false;

            outputs[0].data.vector2Value = Vector2.zero;
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new Vector2InputUI(), spawnPosition);
        }
    }
}
