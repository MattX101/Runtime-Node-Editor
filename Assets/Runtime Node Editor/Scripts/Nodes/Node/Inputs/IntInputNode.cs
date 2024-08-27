using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntInputNode : Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<IntOutputPointer>().value =
                Elements.InputFields[0].text.Length != 0
                ? int.Parse(Elements.InputFields[0].text)
                : 0;
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<IntOutputPointer>().Reset();
        }
    }
}
