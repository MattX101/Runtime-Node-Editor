using UnityEngine;
using TMPro;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3InputNode : Node
    {
        public override void Execute()
        {
            outputs[0].Data.Vector2Value = Vector3.zero;

            TMP_InputField xField = Elements.InputFields[0];
            TMP_InputField yField = Elements.InputFields[1];
            TMP_InputField zField = Elements.InputFields[2];

            if (xField.text.Length != 0)
            {
                float x = float.Parse(xField.text);

                outputs[1].Data.FloatValue = x;
                outputs[0].Data.Vector3Value.x = x;
            }
            if (yField.text.Length != 0)
            {
                float y = float.Parse(yField.text);

                outputs[2].Data.FloatValue = y;
                outputs[0].Data.Vector3Value.y = y;
            }
            if (zField.text.Length != 0)
            {
                float z = float.Parse(zField.text);

                outputs[3].Data.FloatValue = z;
                outputs[0].Data.Vector3Value.z = z;
            }

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].Data.Vector3Value = Vector3.zero;
        }
    }
}
