namespace SimpleParserCombinators;

public static class ParsersFunc
{
    public static Func<string?, (char, string)?> Char(char c) => input =>
    {
        if (!string.IsNullOrEmpty(input) && input[0] == c)
            return (c, input[1..]);
        
        return null;
    };

    public static Func<string?, (int, string)?> Digit() => input =>
    {
        if (!string.IsNullOrEmpty(input) && System.Char.IsDigit(input[0]))
            return (int.Parse(input[0].ToString()), input[1..]);

        return null;
    };

    public static Func<string?, ((T1, T2), string)?> Seq<T1, T2>(Func<string?, (T1, string)?> p1, Func<string?, (T2, string)?> p2)
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