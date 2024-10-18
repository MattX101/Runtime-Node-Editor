using System;
using System.Collections.Generic;
using System.Linq;

namespace RuntimeNodeEditor.UI.Canvas.Node
{
    public partial class NodeUI
    {
        internal byte[] SaveNodeUI()
        {
            List<byte> bytes = new()
            {
                // Node ID
                (byte)NodeId.Length
            };

            bytes.AddRange(NodeId.Select(character => (byte)character));

            // Node Position
            bytes.AddRange(BitConverter.GetBytes(rootRect.localPosition.x));
            bytes.AddRange(BitConverter.GetBytes(rootRect.localPosition.y));

            return bytes.ToArray();
        }
    }
}
