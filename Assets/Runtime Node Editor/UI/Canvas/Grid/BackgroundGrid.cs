using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Grid
{
    internal class BackgroundGrid
    {
        private BackgroundGrid()
        {
            //
        }

        private static BackgroundGrid _instance;
        public static BackgroundGrid Instance => _instance ??= new BackgroundGrid();

        private RawImage _image;

        private const float GridSize = 500.0f;

        private float ScaleX => GlobalData.Camera.pixelWidth / GridSize * GlobalData.Camera.orthographicSize;
        private float Width => ScaleX / GlobalData.ScalerFactor;

        private float ScaleY => GlobalData.Camera.pixelHeight / GridSize * GlobalData.Camera.orthographicSize;
        private float Height => ScaleY / GlobalData.ScalerFactor;

        internal void Init(RawImage image)
        {
            _image = image;

            UpdateGrid();
        }

        internal void UpdateGrid()
        {
            float width = Width;
            float height = Height;

            Pan.PanBackgroundGrid(width, height);

            _image.uvRect = new Rect(
                -(width / 2.0f) - Pan.ViewportPosition.x,
                -(height / 2.0f) - Pan.ViewportPosition.y,
                 width,
                 height
                 );
        }

        internal void SetGridColor(Color color)
        {
            _image.color = color;
        }
    }
}
