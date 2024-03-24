using RuntimeNodeEditor.UI.Canvas.Data;
using RuntimeNodeEditor.UI.Canvas.Lines;
using RuntimeNodeEditor.UI.Data;
using RuntimeNodeEditor.Utils.Colour;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas
{
    public class CanvasUIManager : MonoBehaviour
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
        private Vector3 _screenRes, _screenWorldRes;

        private BackgroundLinesController _backgroundLinesController;

        public void Awake()
        {
            _screenRes = new Vector3(_camera.pixelWidth, _camera.pixelHeight, 1);
            _screenWorldRes = _camera.ScreenToWorldPoint(_screenRes);

            ScreenScale.CalculateScale(_camera.pixelWidth);

            Pan.nodesRect = _nodesRect;
            Zoom.canvasScaler = _canvasScaler;

            SetSizes(1.0f);
            _backgroundLinesController = new BackgroundLinesController(
                _lineMaterial,
                _windowSizeWithBorder,
                _horizontalParent,
                _verticalParent);
            SetCanvasColor();
        }

        private void Update()
        {
            if (CanvasData.canvasIsActive && !(UIData.tabOpened || UIData.windowOpened))
            {
                UpdateCanvasData();

                if (_backgroundLinesController != null)
                {
                    MouseController.CheckMouse();

                    Pan.PanCanvas(_camera);
                    Zoom.ZoomCanvas();

                    ScreenScale.CalculateScale(_camera.pixelWidth);

                    Vector3 updatedScreenRes = new Vector3(_camera.pixelWidth, _camera.pixelHeight, 1);
                    Vector3 updatedScreenWorldRes = _camera.ScreenToWorldPoint(updatedScreenRes);
                    if (_screenRes != updatedScreenRes)
                    {
                        _screenRes = updatedScreenRes;
                        _screenWorldRes = updatedScreenWorldRes;

                        Pan.Reset();
                        Zoom.Reset();

                        SetSizes(Zoom.scale);
                        _backgroundLinesController.DeleteAllLines();
                        _backgroundLinesController.DrawLines(_windowSizeWithBorder);
                    }
                    else
                    {
                        SetSizes(Zoom.scale);
                        if (_cameraBackgroundColour != _camera.backgroundColor) SetCanvasColor();
                        _backgroundLinesController.ManageLines(_canvasSize, _windowSizeWithBorder);
                    }
                }
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
            _backgroundLinesController.LineColour = ColourConversion.HSLToRGB(
                hsl.x,
                hsl.y,
                hsl.z * 0.5f);

            _backgroundLinesController.UpdateLinesColour();
        }
        private void UpdateCanvasData()
        {
            CanvasData.canvasScale = new Vector2(
                _canvasRect.rect.width / _canvasScaler.referenceResolution.x,
                _canvasRect.rect.height / _canvasScaler.referenceResolution.y);
        }

        /*public void Activate()
        {
            CanvasData.canZoom = true;

            if (!(Input.GetMouseButton(0) || Input.GetMouseButton(1)))
                CanvasData.canvasIsActive = true;
        }

        public void Deactivate()
        {
            CanvasData.canZoom = false;

            if (!(Input.GetMouseButton(0) || Input.GetMouseButton(1)))
                CanvasData.canvasIsActive = false;
        }*/
    }
}
