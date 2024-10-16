using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node.Pointer
{
    public class StringOutputPointer : OutputPointer
    {
        public string value = "";

        public StringOutputPointer(RuntimeNodeEditor.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            value = "";
        }

        protected override Color GetLineColor()
        {
            return Data.Colors.String;
        }
    }
}