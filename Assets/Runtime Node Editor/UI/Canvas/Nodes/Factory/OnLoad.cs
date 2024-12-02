using RuntimeNodeEditor.UI.Canvas.Node.Factory.Data;

namespace RuntimeNodeEditor.UI.Canvas.Node.Factory
{
    public static class OnLoad
    {
        public static void Load(RuntimeNodeEditor.Node.Node node, LoadData data)
        {
            if (node.Elements == null)
                return;

            node.Elements.SetElements(data.Texts, data.Booleans, data.SliderValues, data.DropdownValue);
        }
    }
}
