using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class StringEmptyNode : Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<StringOutputPointer>().value = string.Empty;
        }
    }
}