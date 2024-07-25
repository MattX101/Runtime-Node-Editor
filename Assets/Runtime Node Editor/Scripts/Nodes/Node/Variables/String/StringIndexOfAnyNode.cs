using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringIndexOfAnyNode : Node
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

            char[] characters = new char[1] { ' ' };
            int outIndex = -1;
            if (inputs[1].TryGetComponent(out SingleConnectionInputPointer charactersIndicesInputs))
            {
                if (charactersIndicesInputs.connectedOutputPointer)
                {
                    charactersIndicesInputs.connectedOutputPointer.node.Execute();
                    characters = charactersIndicesInputs.connectedOutputPointer.GetComponent<CharArrayOutputPointer>().values;

                    if (characters != null)
                        outIndex = value.IndexOfAny(characters);
                }
            }
            
            outputs[0].GetComponent<IntOutputPointer>().value = outIndex;

            Elements.SetInputField(Elements.InputFields[0], value);
            Elements.SetInputField(Elements.InputFields[1], outIndex.ToString());

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<IntOutputPointer>().Reset();
        }
    }
}