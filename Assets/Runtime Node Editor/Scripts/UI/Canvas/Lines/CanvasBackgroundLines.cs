using RuntimeNodeEditor.Input;
using System.Collections.Generic;
using RuntimeNodeEditor.UI.Canvas.Line;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Lines
{
    internal class CanvasBackgroundLines
    {
        private CanvasBackgroundLines() { }

        private static CanvasBackgroundLines _instance;
        public static CanvasBackgroundLines Instance
        {
            get
            {
                return _instance ??= new CanvasBackgroundLines();
            }
        }

        public bool Initialised;
        
        private Color _lineColour;
        public Color LineColour
        {
            set => _lineColour = value;
        }
        private Material _lineMaterial;

        private Vector4 _bounds;

        private Transform _horizontalLinesParent, _verticalLinesParent;
        private List<CanvasBackgroundLine> _horizontalLines, _verticalLines;

        public void Init(Material lineMaterial, Vector2 windowSize, Transform horizontalLinesParent, Transform verticalLinesParent)
        {
            _lineMaterial = lineMaterial;

            _horizontalLinesParent = horizontalLinesParent;
            _verticalLinesParent = verticalLinesParent;

            _horizontalLines = new List<CanvasBackgroundLine>();
            _verticalLines = new List<CanvasBackgroundLine>();

            DrawLines(windowSize, false);

            Initialised = true;
        }
        
        public void ManageLines(Vector2 canvasSize, Vector2 windowSize)
        {
            UpdateLines(windowSize);
            AddNewLines(canvasSize, windowSize);
        }

        public void UpdateLinesColour()
        {
            foreach (CanvasBackgroundLine line in _horizontalLines)
                line.UpdateMaterial(_lineColour);
            foreach (CanvasBackgroundLine line in _verticalLines)
                line.UpdateMaterial(_lineColour);
        }

        public void DrawLines(Vector2 windowSize, bool clearLines = true)
        {
            if (clearLines)
                DeleteAllLines();
            
            Vector2 scaledWindowScale = windowSize * ScreenScale.Scale;

            DrawHorizontalLine(windowSize.x, 0.0f);
            for (float i = Zoom.Scale; i < scaledWindowScale.y; i += Zoom.Scale)
            {
                float j = i / ScreenScale.Scale;

                DrawHorizontalLine(windowSize.x, j);
                DrawHorizontalLine(windowSize.x, -j);
            }

            DrawVerticalLine(windowSize.y, 0.0f);
            for (float i = Zoom.Scale; i < scaledWindowScale.x; i += Zoom.Scale)
            {
                float j = i / ScreenScale.Scale;

                DrawVerticalLine(windowSize.y, j);
                DrawVerticalLine(windowSize.y, -j);
            }
        }
        private void DrawHorizontalLine(float sizeX, float position)
        {
            _horizontalLines.Add(
                CreateLine(
                    "Horizontal Line", 
                    _horizontalLinesParent, 
                    new Vector3(-sizeX, position, 999), 
                    new Vector3(sizeX, position, 999))
            );
        }
        private void DrawVerticalLine(float sizeY, float position)
        {
            _verticalLines.Add(
                CreateLine(
                    "Vertical Line", 
                    _verticalLinesParent, 
                    new Vector3(position, -sizeY, 999), 
                    new Vector3(position, sizeY, 999))
                );
        }

        private CanvasBackgroundLine CreateLine(string name, Transform parent, Vector3 start, Vector3 end)
        {
            CanvasBackgroundLine canvasBackgroundLine = new CanvasBackgroundLine(
                name,
                parent,
                start,
                end,
                0.04f);
            canvasBackgroundLine.SetMaterial(_lineMaterial, _lineColour);

            return canvasBackgroundLine;
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
                _horizontalLines[i].Offset -= Pan.OffsetZoomed;
                _horizontalLines[i].UpdateHorizontalLine();

                LineRenderer line = _horizontalLines[i].LineRenderer;
                float verticalValue = line.GetPosition(0).y;

                if (verticalValue < -windowSize.y || verticalValue > windowSize.y)
                {
                    DeleteLine(_horizontalLines, i);
                    continue;
                }
                
                float bottom = line.GetPosition(0).y;
                float top = line.GetPosition(1).y;
                    
                _bounds.y = bottom < _bounds.y ? bottom : _bounds.y;
                _bounds.w = top > _bounds.w ? top : _bounds.w;
            }
        }
        private void UpdateVerticalLines(Vector2 windowSize)
        {
            for (int i = _verticalLines.Count - 1; i >= 0; i--)
            {
                _verticalLines[i].Offset -= Pan.OffsetZoomed;
                _verticalLines[i].UpdateVerticalLine();

                LineRenderer line = _verticalLines[i].LineRenderer;
                float horizontalValue = line.GetPosition(0).x;

                if (horizontalValue < -windowSize.x || horizontalValue > windowSize.x)
                {
                    DeleteLine(_verticalLines, i);
                    continue;
                }
                
                float left = line.GetPosition(0).x;
                float right = line.GetPosition(1).x;
                    
                _bounds.x = left < _bounds.x ? left : _bounds.x;
                _bounds.z = right > _bounds.z ? right : _bounds.z;
            }
        }

        private void AddNewLines(Vector2 canvasSize, Vector2 windowSize)
        {
            _bounds /= Zoom.Scale;

            Vector2 size = Zoom.Scale <= 1.0f ? canvasSize : windowSize;

            if (_bounds.x > -size.x) AddNewLine(_bounds.x, windowSize, false);
            if (_bounds.y > -size.y) AddNewLine(_bounds.y, windowSize, false, false);
            if (_bounds.z < size.x)  AddNewLine(_bounds.z, windowSize);
            if (_bounds.w < size.y)  AddNewLine(_bounds.w, windowSize, true, false);
        }
        private void AddNewLine(float position, Vector2 windowSize, bool increment = true, bool isVertical = true)
        {
            position = 
                increment ? 
                position + 1.0f / ScreenScale.Scale : 
                position - 1.0f / ScreenScale.Scale;

            float positionAbs = Mathf.Abs(position) * Zoom.Scale;
            
            switch (isVertical)
            {
                case true when positionAbs <= windowSize.x:
                    DrawVerticalLine(windowSize.y, position);
                    AddNewLine(position, windowSize, increment);
                    break;
                case false when positionAbs <= windowSize.y:
                    DrawHorizontalLine(windowSize.x, position);
                    AddNewLine(position, windowSize, increment, false);
                    break;
            }
        }
        

        private void DeleteAllLines()
        {
            for (int i = 0; i < _horizontalLines.Count; i++) DeleteLine(_horizontalLines, i);
            for (int i = 0; i < _verticalLines.Count; i++)   DeleteLine(_verticalLines, i);
        }
        private void DeleteLine(List<CanvasBackgroundLine> lines, int i)
        {
            Object.Destroy(lines[i].LineRenderer.gameObject);

            lines[i] = lines[^1];
            lines.RemoveAt(lines.Count - 1);
        }
    }
}
