using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.UI.Node;
using TMPro;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class Vector3InputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
            AddOutputPointer(outputs[1]);
            AddOutputPointer(outputs[2]);
            AddOutputPointer(outputs[3]);
        }

        public override void Exectute()
        {
            outputs[0].data.vector2Value = Vector3.zero;

            TMP_InputField xField = nodeUI.inputFields[0];
            TMP_InputField yField = nodeUI.inputFields[1];
            TMP_InputField zField = nodeUI.inputFields[2];

            if (xField.text.Length != 0)
            {
                float x = float.Parse(xField.text);

                outputs[1].data.floatValue = x;
                outputs[0].data.vector3Value.x = x;
            }
            if (yField.text.Length != 0)
            {
                float y = float.Parse(yField.text);

                outputs[2].data.floatValue = y;
                outputs[0].data.vector3Value.y = y;
            }
            if (zField.text.Length != 0)
            {
                float z = float.Parse(zField.text);

                outputs[3].data.floatValue = z;
                outputs[0].data.vector3Value.z = z;
            }

            wasExecuted = true;
        }

        public override void Reset()
        {
            wasExecuted = false;

            outputs[0].data.vector3Value = Vector3.zero;
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new Vector3InputUI(), spawnPosition);
        }
    }
}
