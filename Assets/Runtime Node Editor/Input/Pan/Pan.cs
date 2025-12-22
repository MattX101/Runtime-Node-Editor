using RuntimeNodeEditor.Data;
using Utils.IO.Serialization;
using UnityEngine;

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
            _lastSavedViewportMousePos = Vector2.zero;

            ViewportPosition = Vector2.zero;

            _positionFromOriginZoomed = Vector3.zero;
            _nodesRect.position = new Vector3(0, 0, NodesRectPosition.z);
        }

        public static void Save(FileWriter writer)
        {
            writer.Write(NodesRectPosition.x / GlobalData.ScalerFactor);
            writer.Write(NodesRectPosition.y / GlobalData.ScalerFactor);

            writer.Write(PositionFromOriginZoomed.x);
            writer.Write(PositionFromOriginZoomed.y);
        }

        public static void Load(FileReader reader)
        {
            LoadWorldPan(reader);
            LoadViewportPan(reader);
        }
    }
}
