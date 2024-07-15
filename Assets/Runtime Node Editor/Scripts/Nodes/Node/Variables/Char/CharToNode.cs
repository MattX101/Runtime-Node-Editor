namespace RuntimeNodeEditor.Nodes.Node
{
    public class CharToNode : Node
    {
        public readonly string[] checks =
        {
            "Lower",
            "Upper"
        };

        public override void Execute()
        {
            char c = ' ';
            if (inputs[0].connectedOutputPointer)
            {
                inputs[0].connectedOutputPointer.node.Execute();
                c = inputs[0].connectedOutputPointer.Data.CharValue;

                switch (Elements.Dropdowns[0].Context)
                {
                    case 0:
                        c = ToLower(c);
                        break;
                    case 1:
                        c = ToUpper(c);
                        break;
                    default:
                        break;
                }
            }

            outputs[0].Data.CharValue = c;

            Elements.SetInputField(Elements.InputFields[0], outputs[0].Data.CharValue.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].Data.CharValue = ' ';
        }

        private char ToLower(char c) { return char.ToLower(c); }
        private char ToUpper(char c) { return char.ToUpper(c); }
    }
}