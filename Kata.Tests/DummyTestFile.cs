using NUnit.Framework;

namespace Kata.Tests;

public class DummyTestFile
{
    [Test]
    public void Test_GivenDependanciesInstalled_ShouldNotThrow()
    {
        Assert.DoesNotThrow(() => { });
    }
}
