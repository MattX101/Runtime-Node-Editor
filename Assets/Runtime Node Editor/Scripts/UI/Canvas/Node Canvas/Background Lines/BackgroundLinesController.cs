using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Lines
{
    public class BackgroundLinesController
    {
        private Color _lineColour;
        public Color LineColour
        {
            set { _lineColour = value; }
        }
        private Material _lineMaterial;

        private Vector4 _bounds;

        private Transform _horizontalLinesParent, _verticalLinesParent;
        private List<BackgroundLineController> _horizontalLines, _verticalLines;

        public BackgroundLinesController(Material lineMaterial, Vector2 windowSize, Transform horizontalLinesParent, Transform verticalLinesParent)
        {
            _lineMaterial = lineMaterial;

            _horizontalLinesParent = horizontalLinesParent;
            _verticalLinesParent = verticalLinesParent;

            _horizontalLines = new List<BackgroundLineController>();
            _verticalLines = new List<BackgroundLineController>();

            DrawLines(windowSize);
        }

        public void ManageLines(Vector2 canvasSize, Vector2 windowSize)
        {
            UpdateLines(windowSize);
            AddNewLines(canvasSize, windowSize);
        }

        public void UpdateLinesColour()
        {
            foreach (BackgroundLineController line in _horizontalLines)
                line.UpdateMaterial(_lineColour);
            foreach (BackgroundLineController line in _verticalLines)
                line.UpdateMaterial(_lineColour);
        }

        public void DrawLines(Vector2 windowSize)
        {
            Vector2 scaledWindowScale = windowSize * ScreenScale.scale;

            DrawHorizontalLine(windowSize, 0.0f);
            for (float i = Zoom.scale; i < scaledWindowScale.y; i += Zoom.scale)
            {
                float j = i / ScreenScale.scale;

                DrawHorizontalLine(windowSize, j);
                DrawHorizontalLine(windowSize, -j);
            }

            DrawVerticalLine(windowSize, 0.0f);
            for (float i = Zoom.scale; i < scaledWindowScale.x; i += Zoom.scale)
            {
                float j = i / ScreenScale.scale;

                DrawVerticalLine(windowSize, j);
                DrawVerticalLine(windowSize, -j);
            }
        }
        private void DrawHorizontalLine(Vector2 windowSize, float position)
        {
            Vector3 start = new Vector3(-windowSize.x, position, 999);
            Vector3 end = new Vector3(windowSize.x, position, 999);

            BackgroundLineController backgroundLineController = new BackgroundLineController(
                "Horizontal Line",
                _horizontalLinesParent,
                start,
                end,
                0.04f);
            backgroundLineController.CreateLine(_lineMaterial, _lineColour);

            _horizontalLines.Add(backgroundLineController);
        }
        private void DrawVerticalLine(Vector2 windowSize, float position)
        {
            Vector3 start = new Vector3(position, -windowSize.y, 999);
            Vector3 end = new Vector3(position, windowSize.y, 999);

            BackgroundLineController backgroundLineController = new BackgroundLineController(
                "Vertical Line",
                _verticalLinesParent,
                start,
                end,
                0.04f);
            backgroundLineController.CreateLine(_lineMaterial, _lineColour);

            _verticalLines.Add(backgroundLineController);
        }

        private void UpdateLines(Vector2 windowSize)
        {
            _bounds = new Vector4(
                float.MaxValue,
                float.MaxValue,
                float.MinValue,
                float.MinValue);

            UpdateHorizontalLines(windowSize);
            UpdateVerticalLines(windowSize);
        }
        private void UpdateHorizontalLines(Vector2 windowSize)
        {
            for (int i = _horizontalLines.Count - 1; i >= 0; i--)
            {
                _horizontalLines[i].offset -= Pan.pan / Zoom.scale;
                _horizontalLines[i].UpdateHorizontalLine();

                LineRenderer line = _horizontalLines[i].LineRenderer;
                float bottom = line.GetPosition(0).y;
                float top = line.GetPosition(1).y;
                float verticalValue = line.GetPosition(0).y;

                if (verticalValue < -windowSize.y || verticalValue > windowSize.y)
                {
                    DeleteLine(_horizontalLines, i);
                }
                else
                {
                    _bounds.y = bottom < _bounds.y ? bottom : _bounds.y;
                    _bounds.w = top > _bounds.w ? top : _bounds.w;
                }
            }
        }
        private void UpdateVerticalLines(Vector2 windowSize)
        {
            for (int i = _verticalLines.Count - 1; i >= 0; i--)
            {
                _verticalLines[i].offset -= Pan.pan / Zoom.scale;
                _verticalLines[i].UpdateVerticalLine();

                LineRenderer line = _verticalLines[i].LineRenderer;
                float left = line.GetPosition(0).x;
                float right = line.GetPosition(1).x;
                float horizontalValue = line.GetPosition(0).x;

                if (horizontalValue < -windowSize.x || horizontalValue > windowSize.x)
                {
                    DeleteLine(_verticalLines, i);
                }
                else
                {
                    _bounds.x = left < _bounds.x ? left : _bounds.x;
                    _bounds.z = right > _bounds.z ? right : _bounds.z;
                }
            }
        }

        private void AddNewLines(Vector2 canvasSize, Vector2 windowSize)
        {
            _bounds /= Zoom.scale;

            Vector2 size = Zoom.scale <= 1.0f ? canvasSize : windowSize;

            if (_bounds.x > -size.x) AddNewLine(_bounds.x, windowSize, false, true);
            if (_bounds.y > -size.y) AddNewLine(_bounds.y, windowSize, false, false);
            if (_bounds.z < size.x) AddNewLine(_bounds.z, windowSize, true, true);
            if (_bounds.w < size.y) AddNewLine(_bounds.w, windowSize, true, false);
        }
        private void AddNewLine(float position, Vector2 windowSize, bool increment, bool isVertical)
        {
            if (increment) position += 1.0f / ScreenScale.scale;
            else position -= 1.0f / ScreenScale.scale;

            float value = Mathf.Abs(position) * Zoom.scale;
            if (isVertical && value <= windowSize.x)
            {
                DrawVerticalLine(windowSize, position);
                AddNewLine(position, windowSize, increment, isVertical);
            }
            else if (!isVertical && value <= windowSize.y)
            {
                DrawHorizontalLine(windowSize, position);
                AddNewLine(position, windowSize, increment, isVertical);
            }
        }

        public void DeleteAllLines()
        {
            for (int i = _horizontalLines.Count - 1; i >= 0; i--) DeleteLine(_horizontalLines, i);
            for (int i = _verticalLines.Count - 1; i >= 0; i--) DeleteLine(_verticalLines, i);
        }
        private void DeleteLine(List<BackgroundLineController> lines, int i)
        {
            GameObject lineObject = lines[i].LineRenderer.gameObject;

            lines.Remove(lines[i]);
            GameObject.Destroy(lineObject);
        }
    }
}
