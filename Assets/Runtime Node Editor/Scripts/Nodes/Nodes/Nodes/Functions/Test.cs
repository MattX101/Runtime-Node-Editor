using RuntimeNodeEditor.RuntimeNode.Pointer;
using RuntimeNodeEditor.RuntimeNode.UI;
using UnityEngine;

namespace RuntimeNodeEditor.RuntimeNode
{
    public class Test : Node
    {
        private string _intInput1PointerName;
        private string _intInput2PointerName;

        private string _outputPointerName;

        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddInputPointer(inputs[0]);
            AddInputPointer(inputs[1]);

            AddOutputPointer(outputs[0]);

            _intInput1PointerName = inputs[0].name;
            _intInput2PointerName = inputs[1].name;

            _outputPointerName = outputs[0].name;

            values.Add(_intInput1PointerName, 0);
            values.Add(_intInput2PointerName, 0);
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

            values[_intInput1PointerName] = 0;
            values[_intInput2PointerName] = 0;

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
            return Paste(new TestUI(), spawnPosition);
        }
    }
}
