namespace RuntimeNodeEditor.Nodes.Node
{
    public class XNORNode : Node
    {
        public override void Execute()
        {
            bool a = false;
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                Elements.SetBoolean(Elements.Buttons[0], inputs[0].connectedOutputPointer.Data.BoolValue);
                a = inputs[0].connectedOutputPointer.Data.BoolValue;
            }

            bool b = false;
            if (inputs[1].connectedOutputPointer)
            {
                inputs[1].connectedOutputPointer.node.Execute();
                Elements.SetBoolean(Elements.Buttons[1], inputs[1].connectedOutputPointer.Data.BoolValue);
                b = inputs[1].connectedOutputPointer.Data.BoolValue;
            }

            outputs[0].Data.BoolValue = a == b;
            Elements.SetBoolean(Elements.Buttons[2], outputs[0].Data.BoolValue);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].Data.BoolValue = false;
        }
    }
}
