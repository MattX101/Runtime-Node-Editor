namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntInputNode : Node
    {
        public override void Execute()
        {
            outputs[0].Data.INTValue =
                Elements.InputFields[0].text.Length != 0 
                ? int.Parse(Elements.InputFields[0].text) 
                : 0;

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].Data.INTValue = 0;
        }
    }
}
