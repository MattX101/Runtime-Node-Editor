using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class IntInputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Exectute()
        {
            outputs[0].data.intValue =
                nodeUI.elements.inputFields[0].text.Length != 0 
                ? int.Parse(nodeUI.elements.inputFields[0].text) 
                : 0;

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].data.intValue = 0;
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new IntInputUI(), spawnPosition);
        }
    }
}
