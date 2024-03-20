using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class FloatOutputNode : Node
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
                nodeUI.inputFields[0].text = inputs[0].connectedOutputPointer.data.floatValue.ToString();
            }

            wasExecuted = true;
        }

        public override void Reset()
        {
            wasExecuted = false;
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new FloatOutputUI(), spawnPosition);
        }
    }
}
