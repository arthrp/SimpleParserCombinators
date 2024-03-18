namespace SimpleParserCombinators;

public static class Parsers
{
    public delegate (T, string)? Parser<T>(string input);
    
    public static Parser<char> Char(char c)
    {
        return input =>
        {
            if (!string.IsNullOrEmpty(input) && input[0] == c)
                return (c, input[1..]);
            
            return null;
        };
    }

    public static Parser<string> Str(string s)
    {
        return input =>
        {
            if (!string.IsNullOrEmpty(input) && input.StartsWith(s))
            {
                return (s, input.Substring(s.Length));
            }

            return null;
        };
    }

    public static Parser<(T1, T2)> Seq<T1, T2>(Parser<T1> p1, Parser<T2> p2)
    {
        return input =>
        {
            var r1 = p1(input);
            if (r1 == null) return null;

            var r2 = p2(r1.Value.Item2);
            return (r2 == null) ? null : ((r1.Value.Item1, r2.Value.Item1), r2.Value.Item2);
        };
    }
}