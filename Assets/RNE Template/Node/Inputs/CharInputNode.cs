using RNE.Template.Node.Pointer;

namespace RNE.Template.Node
{
    public class CharInputNode : RuntimeNodeEditor.Node.Node
    {
        protected override void CodeToExecute()
        {
            outputs[0].GetComponent<CharOutputPointer>().value =
                Elements.InputFields[0].text.Length != 0 ?
                Elements.InputFields[0].text[0] : 
                ' ';
        }

        protected override void CodeToReset()
        {
            outputs[0].GetComponent<CharOutputPointer>().Reset();
        }
    }
}
