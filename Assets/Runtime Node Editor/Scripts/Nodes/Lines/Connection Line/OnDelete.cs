using RuntimeNodeEditor.Node.Lines.Data;
using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Node.Line
{
    internal partial class ConnectionLine
    {
        internal InputPointer Input;
        internal OutputPointer Output;

        internal void DestroyLine()
        {
            LinesData.Remove(this);

            if (Input)
            {
                Input.SetLineToNull();
            }

            if (Output)
            {
                Output.RemoveLine(this);
            }

            Object.Destroy(_lineObject);
        }
    }
}
