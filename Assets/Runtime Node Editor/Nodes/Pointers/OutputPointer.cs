using RuntimeNodeEditor.Data;
using RuntimeNodeEditor.Node.Connection.Line;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeNodeEditor.Node.Pointer
{
    public class OutputPointer : Pointer
    {
        internal List<InputPointer> ConnectedInputPointers
        {
            get;
            private set;
        }

        internal List<ConnectionLine> Lines
        {
            get;
            private set;
        }

        private void Update()
        {
            if (Lines == null || Lines.Count == 0)
                return;

            if (!GlobalData.IsDragging && !GlobalData.IsPanning && !GlobalData.IsScrolling)
                return;

            foreach (ConnectionLine line in Lines)
            {
                line.UpdateLinePositions();
            }
        }

        protected virtual void ResetPointer()
        {
            //
        }
        public void Reset()
        {
            ResetPointer();

            if (ConnectedInputPointers == null)
                return;

            ConnectedInputPointers.Clear();
        }

        internal void AddConnection(InputPointer Input)
        {
            ConnectedInputPointers ??= new List<InputPointer>();
            ConnectedInputPointers.Add(Input);
        }

        internal void RemoveConnection(InputPointer Input)
        {
            ConnectedInputPointers.Remove(Input);
        }

        internal void DeleteConnections()
        {
            if (ConnectedInputPointers == null)
                return;

            for (int i = ConnectedInputPointers.Count - 1; i >= 0; i--)
            {
                ConnectedInputPointers[i].EnableUIElement();
                ConnectedInputPointers[i].DeleteConnection();
            }
        }

        internal void AddLine(ConnectionLine connectionLine)
        {
            Lines ??= new List<ConnectionLine>();
            Lines.Add(connectionLine);

            SetLineMaterial();
        }

        internal void RemoveLine(ConnectionLine connectionLine)
        {
            Lines.Remove(connectionLine);
        }

        private void SetLineMaterial()
        {
            Lines[Lines.Count - 1].SetMaterial(GetLineColor());
        }
        protected virtual Color GetLineColor()
        {
            return Color.black;
        }
    }
}