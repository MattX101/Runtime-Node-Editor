using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Nodes.Line;
using RuntimeNodeEditor.Nodes.Pointer;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Lines
{
    internal static class LinesData
    {
        private static readonly List<NodeConnectionLine> DroppedLines = new();
        internal static NodeConnectionLine[] DroppedLinesArray => DroppedLines.ToArray();

        internal static bool NotNullOrEmpty
        { 
            get => DroppedLines.Count <= 0;
        }

        internal static void Add(NodeConnectionLine line)
        {
            DroppedLines.Add(line);
        }

        internal static void Remove(NodeConnectionLine line) 
        { 
            DroppedLines.Remove(line); 
        }

        internal static void DeletePointerConnectionsOnClick(RaycastHit2D raycast)
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