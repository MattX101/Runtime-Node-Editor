using RuntimeNodeEditor.Data;
using Utils.IO.Serialization;
using UnityEngine;

namespace RuntimeNodeEditor.Input
{
    public static class Zoom
    {
        private static float _scale = 1.0f;

        public static void ZoomCanvas()
        {
            if (GlobalData.IsDragging || GlobalData.IsPointing)
                return;

            if (UnityEngine.Input.mouseScrollDelta.y == 0)
            {
                GlobalData.IsScrolling = false;

                return;
            }
            GlobalData.IsScrolling = true;

            float screenScale = GlobalData.Camera.pixelWidth / 1000.0f;
            _scale = Mathf.Clamp(
                _scale + UnityEngine.Input.GetAxis("Mouse ScrollWheel"), 
                0.1f * screenScale, 
                2.0f * screenScale
                );

            SetScaler();
        }

        private static void SetScaler()
        {
            GlobalData.ScalerFactor = _scale;
        }

        public static void Reset()
        {
            GlobalData.IsScrolling = false;
            GlobalData.ScalerFactor = 1.0f;

            _scale = 1.0f;
        }

        public static void Save(FileWriter writer)
        {
            writer.Write(_scale);
        }

        public static void Load(FileReader reader)
        {
            _scale = reader.ReadFloat();
            SetScaler();
        }
    }
}
