using RuntimeNodeEditor.RuntimeNode.Pointer;
using RuntimeNodeEditor.RuntimeNode.UI;
using UnityEngine;

namespace RuntimeNodeEditor.RuntimeNode
{
    public class ExportNode : Node
    {
        private string _inputPointerName;

        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddInputPointer(inputs[0]);

            _inputPointerName = inputs[0].name;

            values.Add(_inputPointerName, 0);
        }

        public override void Exectute()
        {
            //

            wasExecuted = true;
        }

        public override void Reset()
        {
            wasExecuted = false;

            values[_inputPointerName] = 0;
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new ExportUI(), spawnPosition);
        }
    }
}
