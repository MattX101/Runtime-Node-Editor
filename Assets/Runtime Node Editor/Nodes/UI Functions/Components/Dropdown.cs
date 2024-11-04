using TMPro;

namespace RuntimeNodeEditor.Node.UIFunctions.Component
{
    public class Dropdown
    {
        public int Context
        {
            get;
            private set;
        }

        public TextMeshPro Text
        {
            get;
            private set;
        }

        public void CreateText(TextMeshPro text)
        {
            Text = text;
        }

        public void SetContext(int index)
        {
            Context = index;
        }
    }
}