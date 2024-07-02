using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class ColorInputNode : Node
    {
        public override void Execute()
        {
            outputs[1].Data.FloatValue = Elements.Sliders[0].value;
            outputs[2].Data.FloatValue = Elements.Sliders[1].value;
            outputs[3].Data.FloatValue = Elements.Sliders[2].value;
            
            outputs[0].Data.ColorValue = 
                new Color(
                    outputs[1].Data.FloatValue,
                    outputs[2].Data.FloatValue,
                    outputs[3].Data.FloatValue);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].Data.ColorValue = Color.black;
        }
    }
}
