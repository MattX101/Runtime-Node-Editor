using RNE.Template.Node.Pointer;
using RNE.Template.Node.Pointer.Value;

namespace RNE.Template.Node
{
    public class NOTNode : RuntimeNodeEditor.Node.Node
    {
        protected override void CodeToExecute()
        {
            ExecuteInputConnection(0);
        }

        protected override void DataToGetAndSet()
        {
            bool a = PointerValue.GetBool(inputs[0]);
            outputs[0].GetComponent<BoolOutputPointer>().value = !a;

            Elements.SetBoolean(Elements.Buttons[0], a);
            Elements.SetBoolean(Elements.Buttons[1], !a);
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<BoolOutputPointer>().Reset();
        }
    }
}
