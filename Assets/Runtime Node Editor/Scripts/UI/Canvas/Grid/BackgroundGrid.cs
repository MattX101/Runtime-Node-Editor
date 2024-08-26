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

        public bool Initialised;

        private RawImage _image;

        private const float GridSize = 500.0f;

        private float ScaleX => CanvasData.Camera.pixelWidth / GridSize * CanvasData.Camera.orthographicSize;
        private float Width => ScaleX / CanvasData.CanvasScaler.scaleFactor;

        private float ScaleY => CanvasData.Camera.pixelHeight / GridSize * CanvasData.Camera.orthographicSize;
        private float Height => ScaleY / CanvasData.CanvasScaler.scaleFactor;

        public void Init(RawImage image)
        {
            _image = image;

            UpdateGrid();

            Initialised = true;
        }

        public void UpdateGrid()
        {
            Pan.PanBackgroundGrid(Width, Height);

            _image.uvRect = new Rect(
                -(Width / 2.0f) - Pan.ViewportPosition.x,
                -(Height / 2.0f) - Pan.ViewportPosition.y,
                 Width,
                 Height
                 );
        }

        public void SetGridColor(Color color)
        {
            _image.color = color;
        }
    }
}
