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

        internal void Init(RawImage image)
        {
            _image = image;

            UpdateGrid();
        }

        internal void UpdateGrid()
        {
            const float GridSize = 500.0f;

            float width = GlobalData.Camera.pixelWidth / GridSize * GlobalData.Camera.orthographicSize;
            width /= GlobalData.ScalerFactor;

            float height = GlobalData.Camera.pixelHeight / GridSize * GlobalData.Camera.orthographicSize;
            height /= GlobalData.ScalerFactor;

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
