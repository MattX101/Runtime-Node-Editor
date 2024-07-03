namespace RuntimeNodeEditor.Nodes.Node
{
    public class NOTNode : Node
    {
        public override void Execute()
        {
            bool a = false;
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();

                a = inputs[0].connectedOutputPointer.Data.BoolValue;
            }

            Elements.SetBoolean(Elements.Buttons[0], a);

            outputs[0].Data.BoolValue = !a;
            Elements.SetBoolean(Elements.Buttons[1], outputs[0].Data.BoolValue);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].Data.BoolValue = false;
        }
    }
}
