namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    internal class HexValidator : TMPro.TMP_InputValidator
    {
        private readonly char[] _hexChars = new char[16]
        {
            '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'
        };
        internal char[] HexCodes => _hexChars;

        public override char Validate(ref string text, ref int pos, char ch)
        {
            if (text.Length >= 6)
                return '0';

            char input = ch.ToString().ToUpper()[0];

            if (!IsValid(input))
                return '0';

            text = text.Insert(pos, input.ToString());
            pos++;

            return input;
        }

        private bool IsValid(char input)
        {
            foreach (char c in HexCodes)
            {
                if (c == input)
                    return true;
            }

            return false;
        }
    }
}
