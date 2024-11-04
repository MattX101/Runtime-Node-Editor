using RuntimeNodeEditor.Data;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace RuntimeNodeEditor.Input
{
    public static partial class Pan
    {
        private static RectTransform _nodesRect;
        public static RectTransform NodesRect
        {
            set => _nodesRect = value;
        }

        public static Vector3 NodesRectPosition
        {
            get => _nodesRect.position;
        }

        public static void Reset()
        {
            GlobalData.IsPanning = false;

            _lastSavedWorldMousePos = Vector2.zero;
            _positionFromOriginZoomed = Vector3.zero;
            _nodesRect.position = new Vector3(0, 0, NodesRectPosition.z);
        }

        public static byte[] Save()
        {
            List<byte> data = new();
            
            data.AddRange(BitConverter.GetBytes(NodesRectPosition.x / GlobalData.ScalerFactor));
            data.AddRange(BitConverter.GetBytes(NodesRectPosition.y / GlobalData.ScalerFactor));
            
            data.AddRange(BitConverter.GetBytes(PositionFromOriginZoomed.x));
            data.AddRange(BitConverter.GetBytes(PositionFromOriginZoomed.y));

            return data.ToArray();
        }
    }
}
