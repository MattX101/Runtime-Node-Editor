using RuntimeNodeEditor.Functions.UI.Elements;
using RuntimeNodeEditor.Nodes.Pointer;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class FloatInputNode : Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<FloatOutputPointer>().value =
                Elements.InputFields[0].text.Length != 0
                ? InputFieldToFloat.Get(Elements.InputFields[0].text)
                : 0.0f;
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<FloatOutputPointer>().Reset();
        }
    }
}
