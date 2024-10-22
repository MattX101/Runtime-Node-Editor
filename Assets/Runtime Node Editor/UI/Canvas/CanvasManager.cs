using RuntimeNodeEditor.UI.Canvas.Grid;
using RuntimeNodeEditor.Input;
using RuntimeNodeEditor.Data;
using Utils.Colour;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private Color cameraBackgroundColour;

        [SerializeField] private RectTransform nodesRect, canvasRect;

        [SerializeField] private RawImage gridImage;

        private Vector3 _screenRes;
        
        private void Awake()
        {
            Pan.SetNodesRect(nodesRect);
        }

        private void Start()
        {
            BackgroundGrid.Instance.Init(gridImage);

            _screenRes = new Vector3(CanvasData.Camera.pixelWidth, CanvasData.Camera.pixelHeight, 1);

            UpdateCanvasScale();
        }

        private void Update()
        {
            if (UIData.TabOrWindowOpened)
                return;

            UpdateCanvasScale();

            Pan.PanNodesCanvas();
            Zoom.ZoomCanvas();

            Vector3 updatedScreenRes = new Vector3(CanvasData.Camera.pixelWidth, CanvasData.Camera.pixelHeight, 1);
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

        public void Reset()
        {
            UpdateCanvasScale();
        }

        private void SetBackgroundColor()
        {
            if (cameraBackgroundColour == CanvasData.Camera.backgroundColor)
                return;

            CanvasData.Camera.backgroundColor = cameraBackgroundColour;

            Vector3 hsl = ColourConversion.RGBToHSL(cameraBackgroundColour);
            BackgroundGrid.Instance.SetGridColor(ColourConversion.HSLToRGB(
                hsl.x,
                hsl.y,
                hsl.z * 0.9f)
                );
        }
        
        private void UpdateCanvasScale()
        {
            ScreenScale.CalculateScale();

            CanvasData.CanvasScale = 
                new Vector2(canvasRect.rect.width, canvasRect.rect.height) 
                / CanvasData.CanvasScaler.referenceResolution;
        }
    }
}