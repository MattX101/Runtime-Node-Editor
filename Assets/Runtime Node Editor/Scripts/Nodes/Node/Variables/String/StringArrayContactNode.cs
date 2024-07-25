using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringArrayContactNode : Node
    {
        public override void Execute()
        {
            if (!inputs[0].TryGetComponent(out SingleConnectionInputPointer arrayInput))
                return;

            string result = "";
            if (arrayInput.connectedOutputPointer)
            {
                arrayInput.connectedOutputPointer.node.Execute();
                result = string.Concat(arrayInput.connectedOutputPointer.GetComponent<StringArrayOutputPointer>().values);
            }

            outputs[0].GetComponent<StringOutputPointer>().value = result;
            
            Elements.SetInputField(Elements.InputFields[0], result);

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<StringOutputPointer>().Reset();
        }
    }
}