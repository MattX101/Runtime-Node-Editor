using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.UI.Canvas.Grid;
using Utils.Colour;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private Color _cameraBackgroundColour;
        [SerializeField] private RawImage _gridImage;

        [Header("Nodes")]
        [SerializeField] private GameObject _nodesParent;
        [SerializeField] private RectTransform _nodesRect;
        [SerializeField] private RectTransform _nodesCanvasRect;
        [SerializeField] private Tooltip.Window.Window _canvasClearWindow;

        private Vector3 _screenRes;

        private void Awake()
        {
            Pan.NodesRect = _nodesRect;
        }

        private void Start()
        {
            BackgroundGrid.Instance.Init(_gridImage);

            _screenRes = new Vector3(GlobalData.Camera.pixelWidth, GlobalData.Camera.pixelHeight, 1);

            UpdateCanvasScale();
        }

        private void Update()
        {
            if (GlobalData.TabOrWindowOpened)
                return;

            UpdateCanvasScale();

            Pan.PanNodesCanvas();
            Zoom.ZoomCanvas();

            Vector3 updatedScreenRes = new Vector3(GlobalData.Camera.pixelWidth, GlobalData.Camera.pixelHeight, 1);
            if (_screenRes != updatedScreenRes)
            {
                _screenRes = updatedScreenRes;

                Pan.Reset();
                Zoom.Reset();
            }
            else
            {
                SetBackgroundColor();
            }

            BackgroundGrid.Instance.UpdateGrid();
        }

        public void ResetOnValidate()
        {
            if (_nodesParent.transform.childCount > 0)
                return;

            Reset();
        }
        public void Reset()
        {
            UpdateCanvasScale();
        }

        private void SetBackgroundColor()
        {
            if (_cameraBackgroundColour == GlobalData.Camera.backgroundColor)
                return;

            GlobalData.Camera.backgroundColor = _cameraBackgroundColour;

            Vector3 hsl = ColourConversion.RGBToHSL(_cameraBackgroundColour);
            BackgroundGrid.Instance.SetGridColor(ColourConversion.HSLToRGB(
                hsl.x,
                hsl.y,
                hsl.z * 0.9f)
                );
        }
        
        private void UpdateCanvasScale()
        {
            GlobalData.CanvasScale = 
                new Vector2(_nodesCanvasRect.rect.width, _nodesCanvasRect.rect.height) 
                / GlobalData.CanvasScaler.referenceResolution;
        }

        public void ClearCanvas()
        {
            if (_nodesParent.transform.childCount > 0)
            {
                _canvasClearWindow.Create();

                return;
            }
        }
    }
}