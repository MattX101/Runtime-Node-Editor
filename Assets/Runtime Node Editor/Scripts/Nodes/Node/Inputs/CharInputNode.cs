using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class CharInputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
        }

        public override void Exectute()
        {
            outputs[0].data.charValue =
                nodeUI.elements.inputFields[0].text.Length != 0 ?
                nodeUI.elements.inputFields[0].text[0] : 
                ' ';

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].data.charValue = ' ';
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new CharInputUI(), spawnPosition);
        }
    }
}
