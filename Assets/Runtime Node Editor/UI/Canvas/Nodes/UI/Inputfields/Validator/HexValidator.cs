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

        internal int HexCodeToInt(char code)
        {
            return code switch
            {
                '0' => 0, '1' => 1, '2' => 2, '3' => 3,
                '4' => 4, '5' => 5, '6' => 6, '7' => 7,
                '8' => 8, '9' => 9, 'A' => 10,
                'B' => 11, 'C' => 12, 'D' => 13,
                'E' => 14, 'F' => 15, _ => 0,
            };
        }

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
