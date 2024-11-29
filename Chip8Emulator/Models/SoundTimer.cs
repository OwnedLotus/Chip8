namespace Chip8Emulator.Models;

public class SoundTimer : ITimer
{
    public byte Timer { get; private set; }
    public bool IsNonZero()
    {
       return Timer != 0; 
    }

    public void Tick()
    {
        Timer--;
    }

    public void IncrementTimer(byte amount)
    {
        Timer += amount;
    }
}