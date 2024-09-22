using RuntimeNodeEditor.Nodes.Lines;
using RuntimeNodeEditor.Nodes.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Line
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
