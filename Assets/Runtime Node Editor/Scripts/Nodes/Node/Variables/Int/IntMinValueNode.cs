using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntMinValueNode : Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<IntOutputPointer>().value = int.MinValue;
        }
    }
}