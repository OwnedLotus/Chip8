namespace Chip8Emulator.Models;

public interface ITimer
{
    public byte Timer { get; }
    public bool IsNonZero();
    public void Tick();
    public void IncrementTimer(byte amount);
}