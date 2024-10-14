namespace RuntimeNodeEditor.Node.UIFunctions.Component
{
    public static class InputFieldToFloat
    {
        public static float Get(string text)
        {
            if (text.Length == 0)
                return 0.0f;

            if (text.Length == 1 && text[0] == '-')
                return 0.0f;

            return float.Parse(text);
        }
    }
}
