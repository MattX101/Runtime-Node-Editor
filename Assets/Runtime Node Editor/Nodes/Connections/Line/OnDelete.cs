using RuntimeNodeEditor.Node.Connection.Data;
using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.Node.Connection.Line
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
