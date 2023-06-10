namespace CanCRC.App.Logic.Extensions;

public static class StringExtensions
{
    public static byte[] StringToByteArray(this string str)
    {
        var withoutSpacesStr = str.Replace(" ", "");

        return Enumerable.Range(0, withoutSpacesStr.Length/8).
            Select(pos => Convert.ToByte(
                withoutSpacesStr.Substring(pos*8, 8),
                2)
            ).ToArray();
    }

    public static string CheckInput(this string? str, params Func<string, bool>[] checks)
    {
        str.CheckNull();
        
        foreach (var additionalCheck in checks)
        {
            while (true)
            {
                str.CheckNull();
                if (additionalCheck(str!)) break;
                str = Console.ReadLine();
            }
        }
        
        return str!;
    }

    private static void CheckNull(this string? str)
    {
        while (string.IsNullOrEmpty(str))
        {
            Console.WriteLine("Please provide correct input!");
            str = Console.ReadLine();
        }
    }
}