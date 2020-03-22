using System;
using Xunit;
using Xunit.Sdk;
using ATL.Model;

namespace ATL.Model_UnitTest
{
    public class CheckSymbolsTest
    {
        [Fact]
        public void TextContainsSymbols_Test()
        {
            Assert.False(TextTransform.CheckTextContainsSymbols("", Symbol.Brackets));
            Assert.False(TextTransform.CheckTextContainsSymbols("Hello, world!", Symbol.Quotes));
            Assert.True(TextTransform.CheckTextContainsSymbols("Hell(o)", Symbol.Brackets));
            Assert.True(TextTransform.CheckTextContainsSymbols("Organization name: «Pomoika Inc»", Symbol.Quotes));
            Assert.True(TextTransform.CheckTextContainsSymbols("Organization name: \"Pomoika Inc\"", Symbol.Quotes));
        }
    }
}
