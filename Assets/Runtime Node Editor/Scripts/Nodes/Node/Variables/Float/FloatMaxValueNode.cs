using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatMaxValueNode : Node
    {
        public override void Execute()
        {
            outputs[0].GetComponent<FloatOutputPointer>().value = float.MaxValue;
            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}