namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntOutputNode : Node
    {
        public override void Execute()
        {
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                Elements.SetInputField(
                    Elements.InputFields[0],
                    inputs[0].connectedOutputPointer.Data.INTValue.ToString());
            }

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}
