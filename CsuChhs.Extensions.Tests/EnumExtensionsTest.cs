using System.ComponentModel.DataAnnotations;
using Xunit;

namespace CsuChhs.Extensions.Tests;

public class EnumExtensionsTest
{
    enum Test
    {
        [Display(Name = "Test Value 1")]
        TestValue1,
        [Display(Name = "Test Value 2")]
        TestValue2,
        TestValue3
    }
    
    [Fact]
    public void TestDisplayName()
    {
        Assert.Equal("Test Value 1", Test.TestValue1.GetDisplayName());
    }
    
    [Fact]
    public void TestDisplayNameNotFound()
    {
        Assert.Equal("TestValue3", Test.TestValue3.GetDisplayName());
    }
    
    [Fact]
    public void TestNullable()
    {
        Test? nullableValue = null;
        
        Assert.Equal("", nullableValue.GetDisplayName());
    }
    
}