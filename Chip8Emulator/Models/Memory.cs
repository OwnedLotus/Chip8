using System.Collections.Generic;
using System.IO;

namespace Chip8Emulator.Models;

public class Memory
{
    private readonly List<byte> _data = new();
    private FileStream _fileStream;
    private BinaryReader _reader;

    public Memory(string path)
    {
        //read from file
        _fileStream = File.Open(path, FileMode.Open);
        
        if (_fileStream is null) throw new FileNotFoundException();
        _reader = new BinaryReader(_fileStream);
        _reader.BaseStream.Seek(0, SeekOrigin.Begin);
    }

    public byte ReadNextByte()
    {
        if (_reader.BaseStream.Position != _reader.BaseStream.Length)
            return _reader.ReadByte();
        return 0x00;
    }
}

//0x000 -> 0xFFF
//  The first 512 bytes, from 0x000 to 0x1FF, are where the original interpreter was located, and should not be used by programs.
// 
// Most Chip-8 programs start at location 0x200 (512), but some begin at 0x600 (1536). Programs beginning at 0x600 are intended for the ETI 660 computer.
// 