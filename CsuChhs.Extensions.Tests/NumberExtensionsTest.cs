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

        [Fact]
        public void TestToPercent()
        {
            double number, total;

            {
                number = 10;
                total = 50;
                Assert.Equal(20.0, number.ToPercent(total));
            }

            {
                number = 25;
                total = 40;
                Assert.Equal(62.5, number.ToPercent(total, 1));
                Assert.Equal(63.0, number.ToPercent(total, 0));
            }

            {
                number = 30.0;
                total = 46.0;
                Assert.Equal(65.217, number.ToPercent(total, 3));
                Assert.Equal(65.0, number.ToPercent(total, 0));
            }

            {
                number = 25;
                total = 50;
                Assert.Equal(50.0, number.ToPercent(total));
            }

            {
                number = 79.0;
                total = 139.0;
                Assert.Equal(56.83453, number.ToPercent(total, 5));
                Assert.Equal(56.835, number.ToPercent(total, 3));
            }

            {
                number = 185.0;
                total = 36.0;
                Assert.Equal(513.889, number.ToPercent(total, 3));
                Assert.Equal(514.0, number.ToPercent(total, 0));
            }
        }

        [Fact]
        public void TestToIntPercent()
        {
            double number, total;

            {
                number = 40.0;
                total = 80.0;
                Assert.Equal(50, number.ToIntPercent(total));
            }

            {
                number = 40;
                total = 80;
                Assert.Equal(50, number.ToIntPercent(total));
            }

            {
                number = 41;
                total = 50;
                Assert.Equal(82, number.ToIntPercent(total));
            }

            {
                number = 79;
                total = 139;
                Assert.Equal(57, number.ToIntPercent(total));
            }

            {
                number = 185;
                total = 36;
                Assert.Equal(514, number.ToIntPercent(total));
            }
        }

        [Fact]
        public void TestPercentDivideByZeroException()
        {
            double number = 5, total = 0;
            Assert.Throws<DivideByZeroException>(() => number.ToPercent(total));
            Assert.Throws<DivideByZeroException>(() => number.ToIntPercent(total));
        }

        [Fact]
        public void TestToPercentAsString()
        {
            double number = 30.0, total = 46.0;

            Assert.Equal("65.217", number.ToPercent(total, 3).ToString());
            Assert.Equal("65", number.ToIntPercent(total).ToString());
        }

        [Fact]
        public void TestToPercentOrZero()
        {
            double number, total;
            {
                number = 31;
                total = 57;
                Assert.Equal(54.0, number.ToPercentOrZero(total));
                Assert.Equal(54, number.ToIntPercentOrZero(total));
                Assert.Equal(54.4, number.ToPercentOrZero(total, 1));
                Assert.Equal(54.39, number.ToPercentOrZero(total, 2));
                Assert.Equal(54.386, number.ToPercentOrZero(total, 3));
            }

            {
                number = 500;
                total = 0;
                Assert.Equal(0.0, number.ToPercentOrZero(total));
                Assert.Equal(0, number.ToIntPercentOrZero(total));
            }
        }
    }
}
