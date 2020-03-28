using ATL.Model;

using System.Collections.Generic;

using Xunit;

namespace ATL.IntegrationTest
{
    public class BracketsTest
    {
        [Fact]
        public void SuccessfullTest()
        {
            var testCases = new Dictionary<string, string> {
                { "Hell(o)", "Hell(1)" },
                {"Hello, world (12345)!", "Hello, world (5)!" }
            };

            foreach(var test in testCases)
            {
                Assert.True(TextTransform.CheckTextContainsSymbols(test.Key, Symbol.Brackets), "There are no brackets in the text!");            
                Assert.Equal(test.Value, TextTransform.RemoveTextBetweenSymbols(test.Key, Symbol.Brackets));
            }
        }
    }
}
