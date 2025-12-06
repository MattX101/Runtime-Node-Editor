namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    public static class SelectionData
    {
        internal static NodeUI currentActiveNodeUI;
        public static NodeUI ActiveNodeUI => currentActiveNodeUI;

        public static bool ActiveNodeUIIsNull
        {
            get => ActiveNodeUI == null;
        }

        public static RuntimeNodeEditor.Node.Node ActiveNode
        {
            get
            {
                return ActiveNodeUIIsNull ? null : ActiveNodeUI.Node;
            }
        }
    }
}
