using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntMaxValueNode : Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<IntOutputPointer>().value = int.MaxValue;
        }
    }
}