using System.Runtime.CompilerServices;

namespace SimpleParserCombinators.Test;

public class ParserFuncTests
{
    [Test]
    public void CharParser_ParsesValidString()
    {
        var hParser = ParsersFunc.Char('h');

        var parsed = hParser("hello");
        Assert.That(parsed, Is.Not.Null);

        (var res, var rest) = parsed!.Value;
        Assert.That(res, Is.EqualTo('h'));
        Assert.That(rest, Is.EqualTo("ello"));
    }

    [Test]
    public void DigitParser_ParsesValidDigit()
    {
        var parsed = ParsersFunc.Digit()("1hello");
        
        Assert.That(parsed, Is.Not.Null);
        (var res, var rest) = parsed!.Value;
        Assert.That(res, Is.EqualTo(1));
        Assert.That(rest, Is.EqualTo("hello"));
    }

    [Test]
    public void NumberParser_ParsesValidNumber()
    {
        var parsed = ParsersFunc.Number()("123hey");
        
        Assert.That(parsed, Is.Not.Null);
        (var res, var rest) = parsed!.Value;
        Assert.That(res, Is.EqualTo(123));
    }

    [Test]
    public void NumberParser_ParsesValidNumberOnly()
    {
        var parsed = ParsersFunc.Number()("12345");
        Assert.That(parsed, Is.Not.Null);
        (var res, var rest) = parsed!.Value;
        Assert.That(res, Is.EqualTo(12345));
    }
}