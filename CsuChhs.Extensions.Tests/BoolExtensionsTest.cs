using Xunit;

namespace CsuChhs.Extensions.Tests
{
    public class BoolExtensionsTest
    {
        [Fact]
        public void TestYesNoNullable()
        {
            bool? testingBool = false;

            Assert.Equal("No", testingBool.ToYesNo());
        }

        [Fact]
        public void TestYesNo()
        {
            bool testingBool = true;
            Assert.Equal("Yes", testingBool.ToYesNo());
        }
    }
}
