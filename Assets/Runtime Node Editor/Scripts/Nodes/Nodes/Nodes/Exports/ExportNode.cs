using RuntimeNodeEditor.RuntimeNode.Pointer;
using RuntimeNodeEditor.RuntimeNode.UI;
using UnityEngine;

namespace RuntimeNodeEditor.RuntimeNode
{
    public class ExportNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddInputPointer(inputs[0]);
        }

        public override void Exectute()
        {
            if (inputs[0].connectedOutputPointer != null)
            {
                inputs[0].connectedOutputPointer.node.Exectute();
            }

            wasExecuted = true;
        }

        public override void Reset()
        {
            wasExecuted = false;
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new ExportUI(), spawnPosition);
        }
    }
}
