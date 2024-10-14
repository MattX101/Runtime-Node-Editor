using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Node.Line;
using RuntimeNodeEditor.Node.Pointer;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.Node.Lines.Data
{
    internal static class LinesData
    {
        private static readonly List<ConnectionLine> DroppedLines = new();
        internal static ConnectionLine[] DroppedLinesArray => DroppedLines.ToArray();

        internal static bool NotNullOrEmpty
        {
            get
            {
                return DroppedLines.Count <= 0;
            }
        }

        internal static void Add(ConnectionLine line)
        {
            DroppedLines.Add(line);
        }

        internal static void Remove(ConnectionLine line) 
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
            foreach (ConnectionLine line in output.Lines)
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