using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringIndexOfNode : Node
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

            char character = ' ';
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer characterInput))
            {
                if (characterInput.connectedOutputPointer)
                {
                    characterInput.connectedOutputPointer.node.Execute();
                    character = PointerValue.GetChar(characterInput.connectedOutputPointer);
                }
            }

            int outIndex = value.IndexOf(character);
            outputs[0].GetComponent<IntOutputPointer>().value = outIndex;

            Elements.SetInputField(Elements.InputFields[0], value);
            Elements.SetInputField(Elements.InputFields[1], character.ToString());
            Elements.SetInputField(Elements.InputFields[2], outIndex.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<IntOutputPointer>().Reset();
        }
    }
}