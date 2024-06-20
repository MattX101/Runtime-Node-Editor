using RuntimeNodeEditor.Input;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Lines
{
    internal class BackgroundLines
    {
        private BackgroundLines() { }

        private static BackgroundLines _instance;
        public static BackgroundLines Instance
        {
            get
            {
                return _instance ??= new BackgroundLines();
            }
        }

        public bool Initialised = false;
        
        private Color _lineColour;
        public Color LineColour
        {
            set => _lineColour = value;
        }
        private Material _lineMaterial;

        private Vector4 _bounds;

        private Transform _horizontalLinesParent, _verticalLinesParent;
        private List<BackgroundLine> _horizontalLines, _verticalLines;

        public void Init(Material lineMaterial, Vector2 windowSize, Transform horizontalLinesParent, Transform verticalLinesParent)
        {
            _lineMaterial = lineMaterial;

            _horizontalLinesParent = horizontalLinesParent;
            _verticalLinesParent = verticalLinesParent;

            _horizontalLines = new List<BackgroundLine>();
            _verticalLines = new List<BackgroundLine>();

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
            foreach (BackgroundLine line in _horizontalLines)
                line.UpdateMaterial(_lineColour);
            foreach (BackgroundLine line in _verticalLines)
                line.UpdateMaterial(_lineColour);
        }

        public void DrawLines(Vector2 windowSize, bool clearLines)
        {
            if (clearLines)
                DeleteAllLines();
            
            Vector2 scaledWindowScale = windowSize * ScreenScale.scale;

            DrawHorizontalLine(windowSize.x, 0.0f);
            for (float i = Zoom.scale; i < scaledWindowScale.y; i += Zoom.scale)
            {
                float j = i / ScreenScale.scale;

                DrawHorizontalLine(windowSize.x, j);
                DrawHorizontalLine(windowSize.x, -j);
            }

            DrawVerticalLine(windowSize.y, 0.0f);
            for (float i = Zoom.scale; i < scaledWindowScale.x; i += Zoom.scale)
            {
                float j = i / ScreenScale.scale;

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

        private BackgroundLine CreateLine(string name, Transform parent, Vector3 start, Vector3 end)
        {
            BackgroundLine backgroundLineController = new BackgroundLine(
                name,
                parent,
                start,
                end,
                0.04f);
            backgroundLineController.SetMaterial(_lineMaterial, _lineColour);

            return backgroundLineController;
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
                _verticalLines[i].offset -= Pan.pan / Zoom.scale;
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
            _bounds /= Zoom.scale;

            Vector2 size = Zoom.scale <= 1.0f ? canvasSize : windowSize;

            if (_bounds.x > -size.x) AddNewLine(_bounds.x, windowSize, false, true);
            if (_bounds.y > -size.y) AddNewLine(_bounds.y, windowSize, false, false);
            if (_bounds.z < size.x)  AddNewLine(_bounds.z, windowSize, true, true);
            if (_bounds.w < size.y)  AddNewLine(_bounds.w, windowSize, true, false);
        }
        private void AddNewLine(float position, Vector2 windowSize, bool increment, bool isVertical)
        {
            position = 
                increment ? 
                position + 1.0f / ScreenScale.scale : 
                position - 1.0f / ScreenScale.scale;

            float positionAbs = Mathf.Abs(position) * Zoom.scale;
            
            switch (isVertical)
            {
                case true when positionAbs <= windowSize.x:
                    DrawVerticalLine(windowSize.y, position);
                    AddNewLine(position, windowSize, increment, true);
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
        private void DeleteLine(List<BackgroundLine> lines, int i)
        {
            Object.Destroy(lines[i].LineRenderer.gameObject);

            lines[i] = lines[^1];
            lines.RemoveAt(lines.Count - 1);
        }
    }
}
