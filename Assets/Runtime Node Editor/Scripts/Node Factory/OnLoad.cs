using RuntimeNodeEditor.UI.Canvas.Nodes.Node;
using RuntimeNodeEditor.UI.Canvas.Nodes.Save.Data;
using RuntimeNodeEditor.UI.Canvas.Node.Components;

namespace RuntimeNodeEditor.UI.Canvas.Nodes.Save
{
    public static class OnLoad
    {
        public static void Load(LoadData data)
        {
            NodeUI nodeUI = Factory.CreateNode(data.ID, data.Position);
            RuntimeNodeEditor.Nodes.Node.Node node = nodeUI.gameObject.GetComponent<RuntimeNodeEditor.Nodes.Node.Node>();

            if (node.Elements == null)
                return;

            node.Elements.SetElements(data.Texts, data.Booleans, data.SliderValues, data.DropdownContext, data.DropdownText);
        }
    }
}