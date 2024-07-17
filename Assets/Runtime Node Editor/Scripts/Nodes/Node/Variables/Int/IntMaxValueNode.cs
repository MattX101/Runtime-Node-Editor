namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntMaxValueNode : Node
    {
        public override void Execute()
        {
            outputs[0].Data.IntValue = int.MaxValue;
            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}