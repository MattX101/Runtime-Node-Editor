namespace RuntimeNodeEditor.Node.UIFunctions.Component
{
    public static class InputFieldToInt
    {
        public static int Get(string text)
        {
            if (text.Length == 0)
                return 0;

            if (text.Length == 1 && text[0] == '-')
                return 0;

            return int.Parse(text);
        }
    }
}
