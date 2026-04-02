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

        private static readonly DateTime FixedNow = DateTime.Now;

        [Fact]
        public void JustNow_WhenWithinFiveSeconds()
        {
            var dt = FixedNow.AddSeconds(-3);

            var result = dt.ToPrettyTime(FixedNow);

            Assert.Equal("just now", result);
        }

        [Fact]
        public void SecondsAgo_WhenUnderAMinute()
        {
            var dt = FixedNow.AddSeconds(-30);

            var result = dt.ToPrettyTime(FixedNow);

            Assert.Equal("30 seconds ago", result);
        }

        [Fact]
        public void MinutesAgo_WhenUnderAnHour()
        {
            var dt = FixedNow.AddMinutes(-10);

            var result = dt.ToPrettyTime(FixedNow);

            Assert.Equal("10 minutes ago", result);
        }

        [Fact]
        public void HoursAgo_WhenUnder24Hours()
        {
            var dt = FixedNow.AddHours(-3);

            var result = dt.ToPrettyTime(FixedNow);

            Assert.Equal("3 hours ago", result);
        }

        [Fact]
        public void InFutureMinutes()
        {
            var dt = FixedNow.AddMinutes(5);

            var result = dt.ToPrettyTime(FixedNow);

            Assert.Equal("5 minutes from now", result);
        }

        [Fact]
        public void FallsBackToDate_WhenOlderThan24Hours()
        {
            var dt = FixedNow.AddDays(-2);

            var result = dt.ToPrettyTime(FixedNow);

            Assert.Equal(dt.ToString("g"), result);
        }

        [Fact]
        public void FallsBackToDate_WhenMoreThan24HoursInFuture()
        {
            var dt = FixedNow.AddDays(2);

            var result = dt.ToPrettyTime(FixedNow);

            Assert.Equal(dt.ToString("g"), result);
        }

        [Fact]
        public void OneMinuteBoundary()
        {
            var dt = FixedNow.AddMinutes(-1);

            var result = dt.ToPrettyTime(FixedNow);

            Assert.Equal("a minute ago", result);
        }

        [Fact]
        public void OneHourBoundary()
        {
            var dt = FixedNow.AddHours(-1);

            var result = dt.ToPrettyTime(FixedNow);

            Assert.Equal("an hour ago", result);
        }
    }
}
