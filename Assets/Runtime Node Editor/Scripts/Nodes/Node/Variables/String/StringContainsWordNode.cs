using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringContainsWordNode : Node
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

            string toFind = "";
            bool wordFound = false;
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer containsInput))
            {
                if (containsInput.connectedOutputPointer)
                {
                    containsInput.connectedOutputPointer.node.Execute();
                    toFind = PointerValue.GetString(containsInput.connectedOutputPointer);

                    wordFound = value.Contains(toFind);
                }
            }

            outputs[0].GetComponent<BoolOutputPointer>().value = wordFound;

            Elements.SetInputField(Elements.InputFields[0], value);
            Elements.SetInputField(Elements.InputFields[1], toFind);
            Elements.SetBoolean(Elements.Buttons[0], wordFound);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }
    }
}