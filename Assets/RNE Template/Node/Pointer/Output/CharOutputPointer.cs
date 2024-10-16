using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RNE.Template.Node.Pointer
{
    public class CharOutputPointer : OutputPointer
    {
        public char value = ' ';

        public CharOutputPointer(RuntimeNodeEditor.Node.Node node) : base(node) { }

        protected override void ResetPointer()
        {
            value = ' ';
        }

        protected override Color GetLineColor()
        {
            return Data.Colors.Char;
        }
    }
}