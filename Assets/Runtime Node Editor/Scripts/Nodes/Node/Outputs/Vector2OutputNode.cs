namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector2OutputNode : Node
    {
        public override void Execute()
        {
            float x = 0;
            float y = 0;

            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();

                x = inputs[0].connectedOutputPointer.Data.Vector2Value.x;
                y = inputs[0].connectedOutputPointer.Data.Vector2Value.y;
            }

            if (inputs[1].connectedOutputPointer)
            {
                inputs[1].connectedOutputPointer.node.Execute();
                x = inputs[1].connectedOutputPointer.Data.FloatValue;
            }
            if (inputs[2].connectedOutputPointer)
            {
                inputs[2].connectedOutputPointer.node.Execute();
                y = inputs[2].connectedOutputPointer.Data.FloatValue;
            }

            Elements.SetInputField(
                Elements.InputFields[0], 
                x.ToString());
            Elements.SetInputField(
                Elements.InputFields[1], 
                y.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
