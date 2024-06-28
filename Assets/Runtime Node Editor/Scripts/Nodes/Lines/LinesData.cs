using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Lines
{
    public static class LinesData
    {
        public static List<NodeConnectionLine> DroppedLines = new();

        public static void OnNodeDelete(NodeConnectionLine line)
        {
            DroppedLines.Remove(line);
        }

        public static void DeletePointerConnectionsOnClick(RaycastHit2D raycast)
        {
            if (!raycast.collider || CanvasData.IsPointing)
                return;

            if (raycast.collider.TryGetComponent(out OutputPointer outputPointer))
                DeleteOutputConnections(outputPointer);
            else if (raycast.collider.TryGetComponent(out InputPointer inputPointer))
                DeleteInputConnection(inputPointer);
        }

        private static void DeleteOutputConnections(OutputPointer outputPointer)
        {
            foreach (NodeConnectionLine line in outputPointer.Lines)
                DroppedLines.Remove(line);
            outputPointer.DeleteConnections();
        }

        private static void DeleteInputConnection(InputPointer inputPointer)
        {
            DroppedLines.Remove(inputPointer.Line);
            inputPointer.DeleteConnection();
        }
    }
}