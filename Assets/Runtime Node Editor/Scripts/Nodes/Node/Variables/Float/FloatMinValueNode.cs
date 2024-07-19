using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatMinValueNode : Node
    {
        public override void Execute()
        {
            outputs[0].GetComponent<FloatOutputPointer>().value = float.MinValue;
            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}