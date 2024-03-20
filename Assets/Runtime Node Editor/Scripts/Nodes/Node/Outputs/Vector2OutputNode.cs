using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class Vector2OutputNode : Node
    {
        private Vector2 _value = Vector2.zero;

        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddInputPointer(inputs[0]);
            AddInputPointer(inputs[1]);
            AddInputPointer(inputs[2]);
        }

        public override void Exectute()
        {
            if (inputs[0].connectedOutputPointer != null)
            {
                inputs[0].connectedOutputPointer.node.Exectute();
                _value = inputs[0].connectedOutputPointer.data.vector2Value;
            }

            if (inputs[1].connectedOutputPointer != null)
            {
                inputs[1].connectedOutputPointer.node.Exectute();
                _value.x = inputs[1].connectedOutputPointer.data.floatValue;
            }
            if (inputs[2].connectedOutputPointer != null)
            {
                inputs[2].connectedOutputPointer.node.Exectute();
                _value.y = inputs[2].connectedOutputPointer.data.floatValue;
            }

            nodeUI.inputFields[0].text = _value.x.ToString();
            nodeUI.inputFields[1].text = _value.y.ToString();

            wasExecuted = true;
        }

        public override void Reset()
        {
            wasExecuted = false;
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new Vector2OutputUI(), spawnPosition);
        }
    }
}
