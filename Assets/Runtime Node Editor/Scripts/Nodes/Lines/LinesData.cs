using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Lines
{
    internal static class LinesData
    {
        private static List<NodeConnectionLine> DroppedLines = new();
        public static NodeConnectionLine[] DroppedLinesArray => DroppedLines.ToArray();

        public static bool NotNullOrEmpty => DroppedLines is not { Count: > 0 };

        public static void Add(NodeConnectionLine line)
        {
            DroppedLines.Add(line);
        }

        public static void Remove(NodeConnectionLine line)
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
                Remove(line);
            outputPointer.DeleteConnections();
        }

        private static void DeleteInputConnection(InputPointer inputPointer)
        {
            if (inputPointer.TryGetComponent(out SingleConnectionInputPointer single))
            {
                Remove(single.Line);
                single.DeleteConnection();
            }
            else if (inputPointer.TryGetComponent(out MultiConnectionInputPointer multi))
            {
                foreach(NodeConnectionLine line in multi.Lines) 
                    Remove(line);
                multi.DeleteConnections();
            }
        }
    }
}