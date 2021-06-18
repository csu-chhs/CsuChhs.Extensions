using Xunit;

namespace CsuChhs.Extensions.Tests
{
    public class StringExtensionTest
    {
        [Fact]
        public void TestToUrlExtension()
        {
            string url = "sanoteacher.weebly.com";
            Assert.Equal("http://sanoteacher.weebly.com/", url.ToUrl());

            string url2 = "http://sanoteacher.weebly.com";
            Assert.Equal("http://sanoteacher.weebly.com/", url2.ToUrl());

            string url3 = "https://sanoteacher.weebly.com";
            Assert.Equal("https://sanoteacher.weebly.com/", url3.ToUrl());
        }

        [Fact]
        public void TestNumericOnlyStringExtension()
        {
            string myString = "hello12345Iamawesome";
            Assert.Equal("12345", myString.ToNumeric());
        }

        [Fact]
        public void TestTruncate()
        {
            string longString =
                "hello, this is a very long long long long longl ong long string, that should be truncated to 20 characters";
            // Is 23 because we append ... to the end of the length.
            Assert.Equal(23, longString.Truncate(20).Length);
        }

        [Fact]
        public void TestCsvString()
        {
            string stringWithCommas = "string, with, some, commas, apostrophes' and double \"quotes\" ";
            Assert.Equal("string; with; some; commas; apostrophes and double quotes ", stringWithCommas.ToCsvString());
        }

        [Fact]
        public void TestFormattedPhoneSevenDigits()
        {
            Assert.Equal("123-4567", "1234567".ToPhoneNumber());
        }

        [Fact]
        public void TestFormattedPhoneTenDigits()
        {
            Assert.Equal("(123) 123-1234", "1231231234".ToPhoneNumber());
        }

        [Fact]
        public void TestFormattedPhoneSevenWithDashes()
        {
            Assert.Equal("123-4567", "123-4567".ToPhoneNumber());
        }

        [Fact]
        public void TestFormattedPhoneTenWithDashes()
        {
            Assert.Equal("(123) 123-1234", "123-123-1234".ToPhoneNumber());
        }

        [Fact]
        public void TestFormattedPhoneTenWithDashesParentheses()
        {
            Assert.Equal("(123) 123-1234", "(123)-123-1234".ToPhoneNumber());
        }

        [Fact]
        public void TestFormattedPhoneTenWithDashesParenthesesSpaces()
        {
            Assert.Equal("(123) 123-1234", "(123) 123 - 1234".ToPhoneNumber());
        }

        [Fact]
        public void TestIfNotCorrectDigitsIgnore()
        {
            Assert.Equal("1234", "1234".ToPhoneNumber());
        }

        [Fact]
        public void TestFormattedPhoneElevenDigitsWithDash()
        {
            Assert.Equal("+1 (123) 456-7890", "1(123)456-7890".ToPhoneNumber());
        }

        

    }
}
