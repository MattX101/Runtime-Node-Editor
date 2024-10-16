using RuntimeNodeEditor.UI.Canvas.Node.Factory.Data;

namespace RuntimeNodeEditor.UI.Canvas.Node.Factory
{
    public static class OnLoad
    {
        public static void Load(LoadData data)
        {
            NodeUI nodeUI = Factory.CreateNode(data.ID, data.Position);
            RuntimeNodeEditor.Node.Node node = nodeUI.gameObject.GetComponent<RuntimeNodeEditor.Node.Node>();

            if (node.Elements == null)
                return;

            node.Elements.SetElements(data.Texts, data.Booleans, data.SliderValues, data.DropdownContext, data.DropdownText);
        }
    }
}