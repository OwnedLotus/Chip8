using System.IO;

namespace Chip8Emulator.Models;

public class Memory
{
    private readonly byte[] _data = new byte[0xFFF];
    private BinaryReader _reader;

    public Memory(string path)
    {
        // read rom from file as binary
        _reader = new BinaryReader(File.Open(path, FileMode.Open));
    }
}

//0x000 -> 0xFFF
//  The first 512 bytes, from 0x000 to 0x1FF, are where the original interpreter was located, and should not be used by programs.
// 
// Most Chip-8 programs start at location 0x200 (512), but some begin at 0x600 (1536). Programs beginning at 0x600 are intended for the ETI 660 computer.
// 