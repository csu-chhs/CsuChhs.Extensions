using System;
using Xunit;

namespace CsuChhs.Extensions.Tests
{
    public class NumberExtensionsTest
    {
        [Fact]
        public void TestTruncateDecimal()
        {
            double d = 1.1234567;

            Assert.Equal(1.123, NumberExtensions.TruncateDecimals(d, 3));
            Assert.Equal(1.12345, NumberExtensions.TruncateDecimals(d, 5));
            Assert.Equal(1.1, NumberExtensions.TruncateDecimals(d, 1));
            Assert.Equal(1, NumberExtensions.TruncateDecimals(d, 0));
        }

        [Fact]
        public void TestTruncateNullDecimal()
        {
            double d = -1.1234567;

            Assert.Equal(-1.123, NumberExtensions.TruncateDecimals(d, 3));
            Assert.Equal(-1.12345, NumberExtensions.TruncateDecimals(d, 5));
            Assert.Equal(-1.1, NumberExtensions.TruncateDecimals(d, 1));
            Assert.Equal(-1, NumberExtensions.TruncateDecimals(d, 0));

            double? dNull = null;

            Assert.Null(NumberExtensions.TruncateDecimals(dNull, 0));
            Assert.Null(NumberExtensions.TruncateDecimals(dNull, 5));
            Assert.Null(NumberExtensions.TruncateDecimals(dNull, 1));
        }

        [Fact]
        public void TestTruncateDecimalNegativeRoundToException()
        {
            double d = 1.1234567;

            Assert.Throws<ArgumentOutOfRangeException>(() => NumberExtensions.TruncateDecimals(d, -3));
        }

        [Fact]
        public void TestTruncateNullDecimalNegativeRoundToException()
        {
            double? dNull = null;

            Assert.Null(NumberExtensions.TruncateDecimals(dNull, 0));

            double? d = 1.1234567;

            Assert.Throws<ArgumentOutOfRangeException>(() => NumberExtensions.TruncateDecimals(d, -3));
        }
    }
}
