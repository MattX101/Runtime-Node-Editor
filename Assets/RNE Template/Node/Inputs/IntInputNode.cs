using RNE.Template.Node.Pointer;
using RuntimeNodeEditor.Node.UIFunctions.Component;

namespace RNE.Template.Node
{
    public class IntInputNode : RuntimeNodeEditor.Node.Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<IntOutputPointer>().value =
                Elements.InputFields[0].text.Length != 0
                ? InputFieldToInt.Get(Elements.InputFields[0].text)
                : 0;
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<IntOutputPointer>().Reset();
        }
    }
}
