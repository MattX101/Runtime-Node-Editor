using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Node
{
    public static class NodeColor
    {
        public static Color Default => Color.gray;
        public static Color LogicGate => new (0.5f, 0.39f, 0.585f);
        public static Color Array => new (0.75f, 0.75f, 0.75f);
    }
}