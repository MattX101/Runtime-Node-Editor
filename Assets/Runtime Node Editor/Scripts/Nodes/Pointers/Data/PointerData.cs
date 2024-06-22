using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer.Data
{
    public class PointerData
    {
        public int INTValue = 0;
        public float FloatValue = 0.0f;
        public Vector2 Vector2Value = Vector2.zero;
        public Vector3 Vector3Value = Vector3.zero;
        public char CharValue = char.MinValue;
        public string StringValue = "";
        public bool BoolValue = false;
        public Color ColorValue = Color.white;
    }
}