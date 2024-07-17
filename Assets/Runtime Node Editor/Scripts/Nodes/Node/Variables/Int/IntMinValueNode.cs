namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntMinValueNode : Node
    {
        public override void Execute()
        {
            outputs[0].Data.IntValue = int.MinValue;
            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}