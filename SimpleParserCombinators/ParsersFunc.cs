namespace SimpleParserCombinators;

public static class ParsersFunc
{
    public static Func<string?, (char, string)?> Char(char c) => input =>
    {
        if (!string.IsNullOrEmpty(input) && input[0] == c)
            return (c, input[1..]);
        
        return null;
    };

    public static Func<string?, (string, string)?> Str(string s) => input =>
    {
        if (!string.IsNullOrEmpty(input) && input.StartsWith(s))
            return (s, input[s.Length..]);

        return null;
    };

    public static Func<string?, (int, string)?> Digit() => input =>
    {
        if (!string.IsNullOrEmpty(input) && char.IsDigit(input[0]))
            return (int.Parse(input[0].ToString()), input[1..]);

        return null;
    };

    public static Func<string?, (int, string)?> Number() => input =>
    {
        if (string.IsNullOrEmpty(input)) return null;
        int i = 0;
        while (i < input.Length)
        {
            if (!char.IsDigit(input[i])) break;
            i++;
        }

        return (int.Parse(input[..i]), input[i..]);
    };

    public static Func<string?, (T1, T2, string)?> Seq<T1, T2>(Func<string?, (T1, string)?> p1, Func<string?, (T2, string)?> p2)
    {
        return input =>
        {
            var r1 = p1(input);
            if (r1 == null) return null;

            var r2 = p2(r1.Value.Item2);
            return (r2 == null) ? null : (r1.Value.Item1, r2.Value.Item1, r2.Value.Item2);
        };
    }
}