using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringStartsWithNode : Node
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

            char startCharacter = ' ';
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer startsWithInput))
            {
                if (startsWithInput.connectedOutputPointer)
                {
                    startsWithInput.connectedOutputPointer.node.Execute();
                    startCharacter = PointerValue.GetChar(startsWithInput.connectedOutputPointer);
                }
            }

            bool outValue = value.StartsWith(startCharacter);
            outputs[0].GetComponent<BoolOutputPointer>().value = outValue;

            Elements.SetInputField(Elements.InputFields[0], value);
            Elements.SetInputField(Elements.InputFields[1], startCharacter.ToString());
            Elements.SetBoolean(Elements.Buttons[0], outValue);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }
    }
}