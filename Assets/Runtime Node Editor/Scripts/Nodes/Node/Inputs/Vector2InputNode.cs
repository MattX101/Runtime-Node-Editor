using UnityEngine;
using TMPro;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2InputNode : Node
    {
        public override void Execute()
        {
            outputs[0].Data.Vector2Value = Vector2.zero;

            TMP_InputField xField = Elements.InputFields[0];
            TMP_InputField yField = Elements.InputFields[1];

            if (xField.text.Length != 0)
            {
                float x = float.Parse(xField.text);

                outputs[1].Data.FloatValue = x;
                outputs[0].Data.Vector2Value.x = x;
            }
            if (yField.text.Length != 0)
            {
                float y = float.Parse(yField.text);

                outputs[2].Data.FloatValue = y;
                outputs[0].Data.Vector2Value.y = y;
            }

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].Data.Vector2Value = Vector2.zero;
        }
    }
}
