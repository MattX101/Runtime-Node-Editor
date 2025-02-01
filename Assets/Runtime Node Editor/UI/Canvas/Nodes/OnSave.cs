using Utils.IO.Serialization;

namespace RuntimeNodeEditor.UI.Canvas.Node.Save
{
    public static class OnSave
    {
        public static void Save(FileWriter writer, RuntimeNodeEditor.Node.Node[] nodes)
        {
            foreach (RuntimeNodeEditor.Node.Node node in nodes)
            {
                node.GetComponent<NodeUI>().SaveNodeUI(writer);
            }
        }
    }
}
