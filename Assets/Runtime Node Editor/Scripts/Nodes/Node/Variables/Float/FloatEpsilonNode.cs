namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatEpsilonNode : Node
    {
        public override void Execute()
        {
            outputs[0].Data.FloatValue = float.Epsilon;
            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].Data.FloatValue = 0;
        }
    }
}