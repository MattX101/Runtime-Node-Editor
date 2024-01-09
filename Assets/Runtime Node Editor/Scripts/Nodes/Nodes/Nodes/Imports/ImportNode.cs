using RuntimeNodeEditor.RuntimeNode.Pointer;
using RuntimeNodeEditor.RuntimeNode.UI;
using UnityEngine;

namespace RuntimeNodeEditor.RuntimeNode
{
    public class ImportNode : Node
    {
        public int value = 1;

        private string _outputPointerName;

        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);

            _outputPointerName = outputs[0].name;

            values.Add(_outputPointerName, 0);
        }

        public override void Exectute()
        {
            //

            wasExecuted = true;
        }

        public override void Reset()
        {
            wasExecuted = false;

            values[_outputPointerName] = 0;
        }

        public override dynamic GetValue<T>(string valueKey)
        {
            if (!wasExecuted)
                Exectute();

            return values[valueKey];
        }

        public override NodeUI Paste(Vector3 spawnPosition)
        {
            return Paste(new ImportUI(), spawnPosition);
        }
    }
}
