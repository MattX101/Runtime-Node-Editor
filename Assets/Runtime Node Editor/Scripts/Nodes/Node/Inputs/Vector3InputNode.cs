using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class Vector3InputNode : Node
    {
        public Vector3 value = Vector3.zero;

        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Exectute()
        {
            outputs[0].data.vector3Value = value;

            wasExecuted = true;
        }

        public override void Reset()
        {
            wasExecuted = false;

            outputs[0].data.vector3Value = Vector3.zero;
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new Vector3InputUI(), spawnPosition);
        }
    }
}
