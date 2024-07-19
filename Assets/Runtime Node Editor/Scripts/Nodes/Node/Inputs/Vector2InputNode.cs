using UnityEngine;
using TMPro;
using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2InputNode : Node
    {
        public override void Execute()
        {
            outputs[0].GetComponent<Vector2OutputPointer>().value = Vector2.zero;

            TMP_InputField xField = Elements.InputFields[0];
            if (xField.text.Length != 0)
            {
                float x = float.Parse(xField.text);

                outputs[1].GetComponent<FloatOutputPointer>().value = x;
                outputs[0].GetComponent<Vector2OutputPointer>().value.x = x;
            }

            TMP_InputField yField = Elements.InputFields[1];
            if (yField.text.Length != 0)
            {
                float y = float.Parse(yField.text);

                outputs[2].GetComponent<FloatOutputPointer>().value = y;
                outputs[0].GetComponent<Vector2OutputPointer>().value.y = y;
            }

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<Vector2OutputPointer>().Reset();
        }
    }
}
