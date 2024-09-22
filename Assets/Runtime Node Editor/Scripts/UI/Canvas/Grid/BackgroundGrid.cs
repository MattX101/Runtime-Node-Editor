using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Grid
{
    internal class BackgroundGrid
    {
        private BackgroundGrid() { }

        private static BackgroundGrid _instance;
        public static BackgroundGrid Instance => _instance ??= new BackgroundGrid();

        private RawImage _image;

        private const float GridSize = 500.0f;

        private float ScaleX => CanvasData.Camera.pixelWidth / GridSize * CanvasData.Camera.orthographicSize;
        private float Width => ScaleX / CanvasData.ScalerFactor;

        private float ScaleY => CanvasData.Camera.pixelHeight / GridSize * CanvasData.Camera.orthographicSize;
        private float Height => ScaleY / CanvasData.ScalerFactor;

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
