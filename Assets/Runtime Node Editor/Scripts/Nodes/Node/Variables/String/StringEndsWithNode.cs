using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringEndsWithNode : Node
    {
        protected override void CodeToExecute()
        {
            if (!inputs[0].TryGetComponent(out SingleConnectionInputPointer valueInput))
                return;

            string value = "";
            if (valueInput.connectedOutputPointer)
            {
                valueInput.connectedOutputPointer.node.Execute();
                value = PointerValue.GetString(valueInput.connectedOutputPointer);
            }

            char endCharacter = ' ';
            bool outValue = false;
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer endsWithInput))
            {
                if (endsWithInput.connectedOutputPointer)
                {
                    endsWithInput.connectedOutputPointer.node.Execute();
                    endCharacter = PointerValue.GetChar(endsWithInput.connectedOutputPointer);

                    outValue = value.EndsWith(endCharacter);
                }
            }

            outputs[0].GetComponent<BoolOutputPointer>().value = outValue;

            Elements.SetInputField(Elements.InputFields[0], value);
            Elements.SetInputField(Elements.InputFields[1], endCharacter.ToString());
            Elements.SetBoolean(Elements.Buttons[0], outValue);
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }
    }
}