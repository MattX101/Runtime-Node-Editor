using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Node.Connection.Line;
using RuntimeNodeEditor.Node.Pointer;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.Node.Connection.Data
{
    internal static class LinesData
    {
        private static readonly List<ConnectionLine> _droppedLines = new();
        internal static ConnectionLine[] DroppedLinesArray
        {
            get
            {
                return _droppedLines.ToArray();
            }
        }

        internal static bool NotNullOrEmpty
        {
            get
            {
                return _droppedLines.Count <= 0;
            }
        }

        internal static void Add(ConnectionLine line)
        {
            _droppedLines.Add(line);
        }

        internal static void Remove(ConnectionLine line) 
        {
            _droppedLines.Remove(line); 
        }

        internal static void DeletePointerConnectionsOnClick(RaycastHit2D raycast)
        {
            if (!raycast.collider || GlobalData.IsPointing)
                return;

            if (raycast.collider.TryGetComponent(out OutputPointer Output))
            {
                DeleteOutputConnections(Output);
            }
            else if (raycast.collider.TryGetComponent(out InputPointer Input))
            {
                DeleteInputConnection(Input);
            }
        }

        private static void DeleteOutputConnections(OutputPointer Output)
        {
            foreach (ConnectionLine line in Output.Lines)
            {
                Remove(line);
            }

            Output.DeleteConnections();
        }

        private static void DeleteInputConnection(InputPointer Input)
        {
            Remove(Input.Line);
            Input.DeleteConnection();
        }
    }
}