using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatEpsilonNode : Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<FloatOutputPointer>().value = float.Epsilon;
        }
    }
}