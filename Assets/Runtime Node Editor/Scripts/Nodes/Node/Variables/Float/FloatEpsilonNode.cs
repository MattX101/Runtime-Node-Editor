using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatEpsilonNode : Node
    {
        public override void Execute()
        {
            outputs[0].GetComponent<FloatOutputPointer>().value = float.Epsilon;
            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}