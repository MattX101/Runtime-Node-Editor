using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class BoolOutputNode : Node
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
                nodeUI.buttons[0].Toggle(inputs[0].connectedOutputPointer.data.boolValue);
            }

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new BoolOutputUI(), spawnPosition);
        }
    }
}
