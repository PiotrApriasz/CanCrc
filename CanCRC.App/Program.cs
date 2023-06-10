// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using CanCRC.App.Logic;
using CanCRC.App.Logic.Extensions;
using CanCRC.App.Logic.Validation;

Console.WriteLine("Welcome in CRC value calculator for CAN networking systems");
Console.WriteLine("-------------------------------------------------------------------");
Console.WriteLine("Please provide byte sequence from which you want to calculate CRC:");

var sequenceInput = Console.ReadLine()
                                .CheckInput(SequenceValidation.SequenceCheck1, 
                                    SequenceValidation.SequenceCheck2, 
                                    SequenceValidation.SequenceCheck3);
var byteSequence = sequenceInput.StringToByteArray();

Console.WriteLine("Please provide repeat count:");

var repeatCount = Console.ReadLine().CheckInput(RepeatCountValidation.RepeatCountCheck1);
var parsedRepeatCount = long.Parse(repeatCount);

var timer = new Stopwatch();
timer.Start();

var crc = string.Empty;

for (int i = 0; i < parsedRepeatCount; i++)
{
    crc = CrcService.CalculateCrc(byteSequence).ToString("X2");
}

timer.Stop();
var fullDuration = timer.Elapsed.TotalSeconds;
var duration = (fullDuration / parsedRepeatCount);

Console.WriteLine($"Calculated CRC value: {crc}");
Console.WriteLine($"Full calculation time: {fullDuration}");
Console.WriteLine($"Average calculation time per one calculation: {duration}");

Console.ReadKey();                                                      