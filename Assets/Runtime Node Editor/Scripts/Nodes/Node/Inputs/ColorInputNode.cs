using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class ColorInputNode : Node
    {
        public override void AddPointers(InputPointer[] inputs, OutputPointer[] outputs)
        {
            AddOutputPointer(outputs[0]);
            AddOutputPointer(outputs[1]);
            AddOutputPointer(outputs[2]);
            AddOutputPointer(outputs[3]);
        }

        public override void Execute()
        {
            outputs[1].data.floatValue = elements.sliders[0].value;
            outputs[2].data.floatValue = elements.sliders[1].value;
            outputs[3].data.floatValue = elements.sliders[2].value;
            
            outputs[0].data.colorValue = 
                new Color(
                    outputs[1].data.floatValue,
                    outputs[2].data.floatValue,
                    outputs[3].data.floatValue);

            wasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].data.colorValue = Color.black;
        }
    }
}
