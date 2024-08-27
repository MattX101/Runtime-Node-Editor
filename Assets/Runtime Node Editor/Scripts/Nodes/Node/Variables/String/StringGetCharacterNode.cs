using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringGetCharacterNode : Node
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

            int index = 0;
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer characterIndexInput))
            {
                if (characterIndexInput.connectedOutputPointer)
                {
                    characterIndexInput.connectedOutputPointer.node.Execute();
                    index = PointerValue.GetInt(characterIndexInput.connectedOutputPointer);
                }
            }

            char character = ' ';
            if (value.Length > 0)
                character = value[index];
            
            outputs[0].GetComponent<CharOutputPointer>().value = character;

            Elements.SetInputField(Elements.InputFields[0], value);
            Elements.SetInputField(Elements.InputFields[1], index.ToString());
            Elements.SetInputField(Elements.InputFields[2], character.ToString());
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<CharOutputPointer>().Reset();
        }
    }
}