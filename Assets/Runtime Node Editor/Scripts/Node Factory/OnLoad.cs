using RuntimeNodeEditor.Factory.Data;
using RuntimeNodeEditor.UI.Canvas.Node;

namespace RuntimeNodeEditor.Factory
{
    public static class OnLoad
    {
        public static void Load(LoadData data)
        {
            NodeUI nodeUI = Factory.CreateNode(data.ID, data.Position);
            Node.Node node = nodeUI.gameObject.GetComponent<Node.Node>();

            if (node.Elements == null)
                return;

            node.Elements.SetElements(data.Texts, data.Booleans, data.SliderValues, data.DropdownContext, data.DropdownText);
        }
    }
}