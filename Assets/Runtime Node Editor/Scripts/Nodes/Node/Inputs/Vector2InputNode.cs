using RuntimeNodeEditor.Node.Pointer;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class Vector2InputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
            AddOutputPointer(outputs[1]);
            AddOutputPointer(outputs[2]);
        }

        public override void Execute()
        {
            outputs[0].data.vector2Value = Vector2.zero;

            TMP_InputField xField = elements.inputFields[0];
            TMP_InputField yField = elements.inputFields[1];

            if (xField.text.Length != 0)
            {
                float x = float.Parse(xField.text);

                outputs[1].data.floatValue = x;
                outputs[0].data.vector2Value.x = x;
            }
            if (yField.text.Length != 0)
            {
                float y = float.Parse(yField.text);

                outputs[2].data.floatValue = y;
                outputs[0].data.vector2Value.y = y;
            }

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].data.vector2Value = Vector2.zero;
        }
    }
}
