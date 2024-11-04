using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node.Pointer
{
    public class CharOutputPointer : OutputPointer
    {
        public char Value = ' ';

        public CharOutputPointer(RuntimeNodeEditor.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            Value = ' ';
        }

        protected override Color GetLineColor()
        {
            return Data.Colors.Char;
        }
    }
}