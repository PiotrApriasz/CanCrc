namespace CanCRC.App.Logic;

public static class CrcService
{
    public static ushort CalculateCrc(byte[] sequenceBytes)
    {
        ushort crc = 0;

        foreach (var sequenceByte in sequenceBytes)
        {
            crc ^= (ushort)(sequenceByte << 7);
            for (int i = 0; i < 8; i++)
            {
                crc <<= 1;
                if ((crc & 0x8000) != 0)
                {
                    crc ^= 0x4599;
                }
            }

            crc &= 0x7fff;
        }

        return crc;
    }
}