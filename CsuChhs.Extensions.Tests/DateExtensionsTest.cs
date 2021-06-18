using System;
using Xunit;

namespace CsuChhs.Extensions.Tests
{
    public class DateExtensionsTest
    {
        [Fact]
        public void TestMondayIsWeekday()
        {
            DateTime monday = DateTime.Parse("3/23/2020");
            Assert.True(monday.IsWeekday());
        }

        [Fact]
        public void TestSundayIsWeekend()
        {
            DateTime sunday = DateTime.Parse("3/29/2020");
            Assert.False(sunday.IsWeekday());
        }

        [Fact]
        public void TestWorkDay()
        {
            DateTime sunday = DateTime.Parse("08-04-2018");

            Assert.False(sunday.IsWeekday());

            DateTime wednesday = DateTime.Parse("08-08-2018");

            Assert.True(wednesday.IsWeekday());
        }
    }
}
