using nunit_selenium.Core;
using NUnit.Framework;

namespace nunit_selenium.Tests;

[TestFixture]
public class CalculatorTests : TestBase
{
    [Test]
    [Category("Dummy")]
    public void AddTwoNumbers()
    {
        int a = 2;
        int b = 3;
        int expected = 5;
        Calculator calculator = new Calculator();

        int actual = calculator.Add(a, b);

        Assert.That(actual, Is.EqualTo(expected));
    }
}

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}