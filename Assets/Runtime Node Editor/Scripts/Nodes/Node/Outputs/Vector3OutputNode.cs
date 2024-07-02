namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3OutputNode : Node
    {
        public override void Execute()
        {
            float x = 0;
            float y = 0;
            float z = 0;

            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();

                x = inputs[0].connectedOutputPointer.Data.Vector3Value.x;
                y = inputs[0].connectedOutputPointer.Data.Vector3Value.y;
                z = inputs[0].connectedOutputPointer.Data.Vector3Value.z;
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
            if (inputs[3].connectedOutputPointer)
            {
                inputs[3].connectedOutputPointer.node.Execute();
                z = inputs[3].connectedOutputPointer.Data.FloatValue;
            }

            Elements.SetInputField(
                Elements.InputFields[0],
                x.ToString());
            Elements.SetInputField(
                Elements.InputFields[1],
                y.ToString());
            Elements.SetInputField(
                Elements.InputFields[2],
                z.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
