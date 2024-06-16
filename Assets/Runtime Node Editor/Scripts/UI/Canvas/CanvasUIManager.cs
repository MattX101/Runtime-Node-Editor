using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.CanvasInput;
using RuntimeNodeEditor.UI.Canvas.Lines;
using RuntimeNodeEditor.Utils.Colour;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas
{
    internal class CanvasUIManager : MonoBehaviour
    {
        [Header("Camera")]
        [SerializeField] private Camera _camera;
        [SerializeField] private Color _cameraBackgroundColour;

        [Header("Canvas")]
        [SerializeField] private CanvasScaler _canvasScaler;
        [SerializeField] private RectTransform _nodesRect, _canvasRect;

        [Header("Lines")]
        [SerializeField] private Transform _verticalParent;
        [SerializeField] private Transform _horizontalParent;

        [SerializeField] private Material _lineMaterial;

        private Vector2 _windowSize, _windowSizeWithBorder, _canvasSize;
        private Vector3 _screenRes;
        
        public void Awake()
        {
            _screenRes = new Vector3(_camera.pixelWidth, _camera.pixelHeight, 1);

            ScreenScale.CalculateScale(_camera.pixelWidth);

            Pan.nodesRect = _nodesRect;
            Zoom.canvasScaler = _canvasScaler;

            SetSizes(1.0f);
            BackgroundLinesController.Instance.Init(
                _lineMaterial,
                _windowSizeWithBorder,
                _horizontalParent,
                _verticalParent);
            SetCanvasColor();
        }

        private void Update()
        {
            if (!CanvasData.canvasIsActive || UIData.tabOpened || UIData.windowOpened)
                return;

            UpdateCanvasData();

            if (BackgroundLinesController.Instance.Initialised == false)
                return;

            MouseController.CheckMouse();

            Pan.PanCanvas(_camera);
            Zoom.ZoomCanvas();

            ScreenScale.CalculateScale(_camera.pixelWidth);

            Vector3 updatedScreenRes = new Vector3(_camera.pixelWidth, _camera.pixelHeight, 1);
            if (_screenRes != updatedScreenRes)
            {
                _screenRes = updatedScreenRes;

                Pan.Reset();
                Zoom.Reset();

                SetSizes(Zoom.scale);
                BackgroundLinesController.Instance.DrawLines(_windowSizeWithBorder, true);
            }
            else
            {
                SetSizes(Zoom.scale);
                if (_cameraBackgroundColour != _camera.backgroundColor)
                    SetCanvasColor();
                BackgroundLinesController.Instance.ManageLines(_canvasSize, _windowSizeWithBorder);
            }
        }

        private void SetSizes(float zoom)
        {
            _windowSize = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight, 1));
            _windowSizeWithBorder = new Vector3(_windowSize.x + (zoom * 5), _windowSize.y + (zoom * 5));
            _canvasSize = _camera.ScreenToWorldPoint(new Vector3(_canvasRect.rect.width, _canvasRect.rect.height, 1));
        }

        private void SetCanvasColor()
        {
            _camera.backgroundColor = _cameraBackgroundColour;

            Vector3 hsl = ColourConversion.RGBToHSL(_cameraBackgroundColour);
            BackgroundLinesController.Instance.LineColour = ColourConversion.HSLToRGB(
                hsl.x,
                hsl.y,
                hsl.z * 0.5f);

            BackgroundLinesController.Instance.UpdateLinesColour();
        }
        private void UpdateCanvasData()
        {
            CanvasData.canvasScale = new Vector2(
                _canvasRect.rect.width / _canvasScaler.referenceResolution.x,
                _canvasRect.rect.height / _canvasScaler.referenceResolution.y);
        }
    }
}