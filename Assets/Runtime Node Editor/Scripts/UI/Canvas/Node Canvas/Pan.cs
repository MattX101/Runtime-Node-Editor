using RuntimeNodeEditor.UI.Canvas.Data;
using System;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas
{
    public static class Pan
    {
        private static Vector2 _lastFrameMousePos;

        public static Vector3 pan, positionFromOrigin;

        public static RectTransform nodesRect;

        public static void PanCanvas(Camera camera)
        {
            pan = Vector3.zero;
            if (!CanvasData.isDraging && !CanvasData.isPointing)
            {
                Vector2 mousePos = MouseController.GetMouseWorldPosition(camera);

                if (Input.GetMouseButton(1) == true)
                {
                    CanvasData.isPanning = true;

                    float x = Mathf.Clamp(mousePos.x - _lastFrameMousePos.x, -1, 1);
                    float y = Mathf.Clamp(mousePos.y - _lastFrameMousePos.y, -1, 1);

                    nodesRect.position = new Vector3(
                        nodesRect.position.x + x, 
                        nodesRect.position.y + y, 
                        nodesRect.position.z);

                    pan = new Vector3(x, y, 0);

                    Vector3 halfRes = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
                    positionFromOrigin = halfRes - camera.WorldToScreenPoint(-nodesRect.position);
                }
                else
                {
                    CanvasData.isPanning = false;
                }

                _lastFrameMousePos = mousePos;
            }
        }

        public static void UpdatePositionFromOrigin()
        {
            positionFromOrigin /= Zoom.scale;
        }

        public static void Reset()
        {
            CanvasData.isPanning = false;

            _lastFrameMousePos = Vector2.zero;

            pan = Vector3.zero;
            positionFromOrigin = Vector3.zero;

            nodesRect.position = new Vector3(0, 0, nodesRect.position.z);
        }

        public static byte[] Save()
        {
            byte[] x = BitConverter.GetBytes(positionFromOrigin.x);
            byte[] y = BitConverter.GetBytes(positionFromOrigin.y);
            byte[] z = BitConverter.GetBytes(positionFromOrigin.z);

            byte[] bytes = new byte[12];

            for (int i = 0; i < 4; i++)
            {
                bytes[i] = x[i];
                bytes[i + 4] = y[i];
                bytes[i + 8] = z[i];
            }

            return bytes;
        }
    }
}
