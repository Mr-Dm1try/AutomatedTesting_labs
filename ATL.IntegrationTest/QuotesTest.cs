using ATL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ATL.IntegrationTest
{
    public class QuotesTest
    {
        [Fact]
        public void DoubleQuotesTest()
        {
            var testCases = new Dictionary<string, string> {
                { "Organization name: \"Pomoika Inc\"", "Organization name: \"11\"" },
                {"\"Hi there!\" - he said", "\"9\" - he said" }
            };

            foreach (var test in testCases)
            {
                Assert.True(TextTransform.CheckTextContainsSymbols(test.Key, Symbol.Quotes), "There are no quotes in the text!");
                Assert.Equal(test.Value, TextTransform.RemoveTextBetweenSymbols(test.Key, Symbol.Quotes));
            }
        }

        [Fact]
        public void TreeQuotesTest()
        {
            var testCases = new Dictionary<string, string> {
                { "Organization name: «Pomoika Inc»", "Organization name: «11»" },
                {"«Hi there!» - he said", "«9» - he said" }
            };

            foreach (var test in testCases)
            {
                Assert.True(TextTransform.CheckTextContainsSymbols(test.Key, Symbol.Quotes), "There are no quotes in the text!");
                Assert.Equal(test.Value, TextTransform.RemoveTextBetweenSymbols(test.Key, Symbol.Quotes));
            }
        }
    }
}
