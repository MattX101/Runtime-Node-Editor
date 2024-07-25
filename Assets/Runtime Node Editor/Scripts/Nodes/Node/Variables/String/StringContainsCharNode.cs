using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringContainsCharNode : Node
    {
        public override void Execute()
        {
            if (!inputs[0].TryGetComponent(out SingleConnectionInputPointer valueInput))
                return;

            string value = "";
            if (valueInput.connectedOutputPointer)
            {
                valueInput.connectedOutputPointer.node.Execute();
                value = PointerValue.GetString(valueInput.connectedOutputPointer);
            }

            char toFind = ' ';
            bool charFound = false;
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer containsInput))
            {
                if (containsInput.connectedOutputPointer)
                {
                    containsInput.connectedOutputPointer.node.Execute();
                    toFind = PointerValue.GetChar(containsInput.connectedOutputPointer);

                    charFound = value.Contains(toFind);
                }
            }
            
            outputs[0].GetComponent<BoolOutputPointer>().value = charFound;

            Elements.SetInputField(Elements.InputFields[0], value);
            Elements.SetInputField(Elements.InputFields[1], toFind.ToString());
            Elements.SetBoolean(Elements.Buttons[0], charFound);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }
    }
}