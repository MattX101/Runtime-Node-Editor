using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using Utils.Colour;
using UnityEngine;
using UnityEngine.UI;
using RuntimeNodeEditor.UI.Canvas.Grid;

namespace RuntimeNodeEditor.UI.Canvas
{
    internal class CanvasManager : MonoBehaviour
    {
        [Header("Camera")]
        [SerializeField] private Camera camera;
        [SerializeField] private Color cameraBackgroundColour;

        [Header("Canvas")]
        [SerializeField] private CanvasScaler canvasScaler;
        [SerializeField] private RectTransform nodesRect, canvasRect;

        [Header("Grid")]
        [SerializeField] private RawImage gridImage;

        private Vector2 _windowSize, _windowSizeWithBorder, _canvasSize;
        private Vector3 _screenRes;
        
        public void Awake()
        {
            CanvasData.Camera = camera;
            CanvasData.CanvasScaler = canvasScaler;
            
            _screenRes = new Vector3(camera.pixelWidth, camera.pixelHeight, 1);

            ScreenScale.CalculateScale();

            Pan.NodesRect = nodesRect;

            SetSizes(1.0f);
            BackgroundGrid.Instance.Init(gridImage);

            UpdateData();
        }

        private void Update()
        {
            if (UIData.TabOrWindowOpened)
                return;

            UpdateData();

            if (BackgroundGrid.Instance.Initialised == false)
                return;

            Pan.PanNodesCanvas();
            Zoom.ZoomCanvas();

            ScreenScale.CalculateScale();

            Vector3 updatedScreenRes = new Vector3(camera.pixelWidth, camera.pixelHeight, 1);
            if (_screenRes != updatedScreenRes)
            {
                _screenRes = updatedScreenRes;

                Pan.Reset();
                Zoom.Reset();

                SetSizes(CanvasData.CanvasScaler.scaleFactor);
            }
            else
            {
                SetSizes(CanvasData.CanvasScaler.scaleFactor);
                if (cameraBackgroundColour != camera.backgroundColor)
                    SetColor();
            }

            BackgroundGrid.Instance.UpdateGrid();
        }

        public void Reset()
        {
            UpdateData();
        }

        private void SetSizes(float zoom)
        {
            _windowSize = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, 1));
            _windowSizeWithBorder = new Vector3(_windowSize.x + zoom * 5, _windowSize.y + zoom * 5);
            _canvasSize = camera.ScreenToWorldPoint(new Vector3(canvasRect.rect.width, canvasRect.rect.height, 1));
        }

        private void SetColor()
        {
            camera.backgroundColor = cameraBackgroundColour;

            Vector3 hsl = ColourConversion.RGBToHSL(cameraBackgroundColour);
            BackgroundGrid.Instance.SetGridColor(ColourConversion.HSLToRGB(
                hsl.x,
                hsl.y,
                hsl.z * 0.9f)
                );
        }
        
        private void UpdateData()
        {
            CanvasData.CanvasScale = new Vector2(canvasRect.rect.width, canvasRect.rect.height);
            CanvasData.CanvasScale /= canvasScaler.referenceResolution;
        }
    }
}