using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.UI.Canvas.Lines;
using Utils.Colour;
using UnityEngine;
using UnityEngine.UI;

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

        [Header("Lines")]
        [SerializeField] private Transform verticalParent;
        [SerializeField] private Transform horizontalParent;

        [SerializeField] private Material lineMaterial;

        private Vector2 _windowSize, _windowSizeWithBorder, _canvasSize;
        private Vector3 _screenRes;
        
        public void Awake()
        {
            CanvasData.Camera = camera;
            CanvasData.CanvasScaler = canvasScaler;
            
            _screenRes = new Vector3(camera.pixelWidth, camera.pixelHeight, 1);

            ScreenScale.CalculateScale(camera.pixelWidth);

            Pan.NodesRect = nodesRect;

            SetSizes(1.0f);
            CanvasBackgroundLines.Instance.Init(
                lineMaterial,
                _windowSizeWithBorder,
                horizontalParent,
                verticalParent);
            UpdateData();
        }

        private void Update()
        {
            if (UIData.TabOrWindowOpened)
                return;

            UpdateData();

            if (CanvasBackgroundLines.Instance.Initialised == false)
                return;

            Pan.PanCanvas(camera);
            Zoom.ZoomCanvas();

            ScreenScale.CalculateScale(camera.pixelWidth);

            Vector3 updatedScreenRes = new Vector3(camera.pixelWidth, camera.pixelHeight, 1);
            if (_screenRes != updatedScreenRes)
            {
                _screenRes = updatedScreenRes;

                Pan.Reset();
                Zoom.Reset();

                SetSizes(Zoom.Scale);
                CanvasBackgroundLines.Instance.DrawLines(_windowSizeWithBorder);
            }
            else
            {
                SetSizes(Zoom.Scale);
                if (cameraBackgroundColour != camera.backgroundColor)
                    SetColor();
                CanvasBackgroundLines.Instance.ManageLines(_canvasSize, _windowSizeWithBorder);
            }
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
            CanvasBackgroundLines.Instance.LineColour = ColourConversion.HSLToRGB(
                hsl.x,
                hsl.y,
                hsl.z * 0.5f);

            CanvasBackgroundLines.Instance.UpdateLinesColour();
        }
        
        private void UpdateData()
        {
            CanvasData.CanvasScale = new Vector2(canvasRect.rect.width, canvasRect.rect.height);
            CanvasData.CanvasScale /= canvasScaler.referenceResolution;
        }
    }
}