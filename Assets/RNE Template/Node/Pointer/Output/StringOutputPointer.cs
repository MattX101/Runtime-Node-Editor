using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node.Pointer
{
    public class StringOutputPointer : OutputPointer
    {
        public string Value = "";

        public StringOutputPointer(RuntimeNodeEditor.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            Value = "";
        }

        protected override Color GetLineColor()
        {
            return Data.Colors.String;
        }
    }
}