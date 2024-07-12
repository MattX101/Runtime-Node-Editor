namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatMaxValueNode : Node
    {
        public override void Execute()
        {
            outputs[0].Data.FloatValue = float.MaxValue;
            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}