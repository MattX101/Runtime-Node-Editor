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

        public static void Add(NodeConnectionLine line) => DroppedLines.Add(line);

        public static void Remove(NodeConnectionLine line) => DroppedLines.Remove(line);

        public static void DeletePointerConnectionsOnClick(RaycastHit2D raycast)
        {
            if (!raycast.collider || CanvasData.IsPointing)
                return;

            if (raycast.collider.TryGetComponent(out OutputPointer output))
                DeleteOutputConnections(output);
            else if (raycast.collider.TryGetComponent(out InputPointer input))
                DeleteInputConnection(input);
        }

        private static void DeleteOutputConnections(OutputPointer output)
        {
            foreach (NodeConnectionLine line in output.Lines)
                Remove(line);
            output.DeleteConnections();
        }

        private static void DeleteInputConnection(InputPointer input)
        {
            Remove(input.Line);
            input.DeleteConnection();
        }
    }
}