using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ATL.Model
{
    public static class TextTransform
    {
        private static List<char> QuotesSymbols = new List<char> { '"', '«', '»' };
        private static List<char> BracketsSymbols = new List<char> { '(', ')' };

        private static Regex bracketsReg = new Regex(@"\(.*?\)");
        private static Regex quotesReg1 = new Regex(@"\u0022.*?\u0022");
        private static Regex quotesReg2 = new Regex(@"«.*?»");
        

        public static bool CheckTextContainsSymbols(string text, Symbol symbol)
        {
            switch (symbol)
            {
                case Symbol.Brackets:                
                    return text.Any(ch => BracketsSymbols.Contains(ch));
                case Symbol.Quotes:
                    return text.Any(ch => QuotesSymbols.Contains(ch));
                default: throw new NotImplementedException();    
            }
        }

        public static string RemoveTextBetweenSymbols(string text, Symbol symbol)
        {
            MatchCollection matches = null;
            switch (symbol)
            {
                case Symbol.Brackets:
                {
                    matches = bracketsReg.Matches(text);
                    break;
                }
                case Symbol.Quotes:
                {
                    if (text.Contains(QuotesSymbols[0]) && !text.Contains(QuotesSymbols[1]) && !text.Contains(QuotesSymbols[2]))
                        matches = quotesReg1.Matches(text);
                    else if (!text.Contains(QuotesSymbols[0]) && (text.Contains(QuotesSymbols[1]) || text.Contains(QuotesSymbols[2])))
                        matches = quotesReg2.Matches(text);
                    else
                        throw new ArgumentException("Use only one type of quotes!", nameof(text));
                    break;
                }
                default: throw new NotImplementedException();
            }

            if (matches.Count > 0)
                foreach (Match match in matches)
                {
                    var count = match.Value.Length - 2;
                    text = text.Replace(match.Value, match.Value[0] + count.ToString() + match.Value[count + 1]);
                }

            return text;
        }
    }
    public enum Symbol
    {
        Quotes,
        Brackets
    }
}
