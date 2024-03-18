namespace SimpleParserCombinators;

class Program
{
    static void Main(string[] args)
    {
        var helParser = Parsers.Str("hel");
        var loParser = Parsers.Str("lo");
        var helloParser = Parsers.Seq(helParser, loParser);

        var x = helloParser("hello, world");
        
        Console.WriteLine(x.Value.Item1.Item1);
    }
}
