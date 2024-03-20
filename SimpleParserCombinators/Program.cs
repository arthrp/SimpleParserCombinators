namespace SimpleParserCombinators;

class Program
{
    static void Main(string[] args)
    {
        var helParser = ParsersFunc.Str("hel");
        var loParser = ParsersFunc.Str("lo");
        var helloParser = ParsersFunc.Seq(helParser, loParser);

        var (x, y, _) = helloParser("hello, world")!.Value;
        
        Console.WriteLine(x);
        Console.WriteLine(y);
    }
}
