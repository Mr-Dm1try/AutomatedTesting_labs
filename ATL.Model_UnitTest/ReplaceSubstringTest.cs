using ATL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ATL.Model_UnitTest
{
    public class ReplaceSubstringTest
    {
        [Fact]
        public void ReplaceSubstringInText_Test()
        {
            Assert.Equal("", TextTransform.RemoveTextBetweenSymbols("", Symbol.Brackets));
            Assert.Equal("Hello, world!", TextTransform.RemoveTextBetweenSymbols("Hello, world!", Symbol.Quotes));
            Assert.Equal("Hell(1)", TextTransform.RemoveTextBetweenSymbols("Hell(o)", Symbol.Brackets));
            Assert.Equal("Organization name: «11»", TextTransform.RemoveTextBetweenSymbols("Organization name: «Pomoika Inc»", Symbol.Quotes));
            Assert.Equal("Organization name: \"11\"", TextTransform.RemoveTextBetweenSymbols("Organization name: \"Pomoika Inc\"", Symbol.Quotes));
        }
    }
}
