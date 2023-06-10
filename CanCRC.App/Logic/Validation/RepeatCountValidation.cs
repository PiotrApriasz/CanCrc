namespace CanCRC.App.Logic.Validation;

public static class RepeatCountValidation
{
    public static bool RepeatCountCheck1(string repeatCount)
    {
        if (!long.TryParse(repeatCount, out var parsed))
        {
            Console.WriteLine("Repeat count should be a number");
            return false;
        }

        if (parsed is < 1 or > 1000000000)
        {
            Console.WriteLine("Repeat count should be greater than 1 and less than 10^9");
            return false;
        }

        return true;
    }
}