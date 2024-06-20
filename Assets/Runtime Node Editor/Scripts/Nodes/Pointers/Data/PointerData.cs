using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Pointer.Data
{
    public class PointerData
    {
        public int intValue = 0;
        public float floatValue = 0.0f;
        public Vector2 vector2Value = Vector2.zero;
        public Vector3 vector3Value = Vector3.zero;
        public char charValue = char.MinValue;
        public string stringValue = "";
        public bool boolValue = false;
        public Color colorValue = Color.white;
    }
}