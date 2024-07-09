namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatMinValueNode : Node
    {
        public override void Execute()
        {
            outputs[0].Data.FloatValue = float.MinValue;
            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].Data.FloatValue = 0;
        }
    }
}