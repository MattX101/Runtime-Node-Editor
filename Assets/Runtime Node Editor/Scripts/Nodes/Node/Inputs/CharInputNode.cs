using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class CharInputNode : Node
    {
        public override void Execute()
        {
            outputs[0].GetComponent<CharOutputPointer>().value =
                Elements.InputFields[0].text.Length != 0 ?
                Elements.InputFields[0].text[0] : 
                ' ';

            WasExecuted = true;
        }

        public override void Reset()
        {
            ResetExecution();

            outputs[0].GetComponent<CharOutputPointer>().Reset();
        }
    }
}
