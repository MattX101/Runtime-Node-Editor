namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatInputNode : Node
    {
        public override void Execute()
        {
            outputs[0].Data.FloatValue =
                Elements.InputFields[0].text.Length != 0
                ? float.Parse(Elements.InputFields[0].text)
                : 0.0f;

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].Data.FloatValue = 0.0f;
        }
    }
}
