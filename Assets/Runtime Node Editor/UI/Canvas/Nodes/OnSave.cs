using Utils.IO.Serialization;

namespace RuntimeNodeEditor.UI.Canvas.Node.Save
{
    public static class OnSave
    {
        public static void Save(FileWriter writer)
        {
            foreach (NodeUI node in NodeUIDictionary.NodesUI.Values)
            {
                node.SaveNodeUI(writer);
            }
        }
    }
}
