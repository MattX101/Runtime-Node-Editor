using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatMaxValueNode : Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<FloatOutputPointer>().value = float.MaxValue;
        }
    }
}