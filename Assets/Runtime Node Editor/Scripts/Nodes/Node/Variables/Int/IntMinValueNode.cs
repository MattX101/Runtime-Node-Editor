using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntMinValueNode : Node
    {
        public override void Execute()
        {
            outputs[0].GetComponent<IntOutputPointer>().value = int.MinValue;
            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();
        }
    }
}