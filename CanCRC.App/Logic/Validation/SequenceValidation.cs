namespace CanCRC.App.Logic.Validation;

public static class SequenceValidation
{
    public static bool SequenceCheck1(string sequence)
    {
        if (sequence.Length <= 96) return true;
        Console.WriteLine("Please provide sequence with less than 97 bits!");
        return false;
    }

    public static bool SequenceCheck2(string sequence)
    {
        if (sequence.All(ch => "01".Contains(ch))) return true;
        Console.WriteLine("There should be only 1 and 0 in sequence");
        return false;
    }

    public static bool SequenceCheck3(string sequence)
    {
        if (sequence.Length % 8 == 0) return true;
        Console.WriteLine("Sequence length should be multiple of 8");
        return false;
    }
}