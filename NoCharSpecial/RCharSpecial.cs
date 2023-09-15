using System;
using System.Text.RegularExpressions;


namespace NoCharSpecial
{
    class RCharSpecial
    {
        public static string Remove(string Text)
        {
            return Regex.Replace(Text, "[^0-9a-zA-Z]+", "");
        }
    }
}
