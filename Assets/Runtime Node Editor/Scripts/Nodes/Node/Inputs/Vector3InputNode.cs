using UnityEngine;
using TMPro;
using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3InputNode : Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<Vector3OutputPointer>().value = Vector3.zero;

            TMP_InputField xField = Elements.InputFields[0];
            if (xField.text.Length != 0)
            {
                float x = float.Parse(xField.text);

                outputs[1].GetComponent<FloatOutputPointer>().value = x;
                outputs[0].GetComponent<Vector3OutputPointer>().value.x = x;
            }

            TMP_InputField yField = Elements.InputFields[1];
            if (yField.text.Length != 0)
            {
                float y = float.Parse(yField.text);

                outputs[2].GetComponent<FloatOutputPointer>().value = y;
                outputs[0].GetComponent<Vector3OutputPointer>().value.y = y;
            }

            TMP_InputField zField = Elements.InputFields[2];
            if (zField.text.Length != 0)
            {
                float z = float.Parse(zField.text);

                outputs[3].GetComponent<FloatOutputPointer>().value = z;
                outputs[0].GetComponent<Vector3OutputPointer>().value.z = z;
            }
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<Vector3OutputPointer>().Reset();
        }
    }
}
