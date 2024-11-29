namespace Chip8Emulator.Models;

public struct Nibble
{
    private byte _value;

    public Nibble(byte value)
    {
        _value = (byte)(value & 0x0F);
    }

    public byte Value
    {
        get => _value;
        set => _value = (byte)(value | 0x0F);
    }
    
    public static implicit operator byte(Nibble nibble) => nibble._value;
}