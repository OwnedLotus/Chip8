using System.Collections.Immutable;
using System.IO;

namespace Chip8Emulator.Models;

public class Memory
{
    private readonly ImmutableList<byte> _memory;
    
    public Memory(string path)
    {
        //read from file
        var fileStream = File.Open(path, FileMode.Open);
        
        if (fileStream is null) throw new FileNotFoundException($"Specified file {path} was not found.");
        
        var reader = new BinaryReader(fileStream);
        reader.BaseStream.Seek(0, SeekOrigin.Begin);
        _memory = [..reader.ReadBytes((int)reader.BaseStream.Length)];
        
        reader.Close();
        fileStream.Close();
    }

    public byte ReadByteAt(ushort pc)
    {
        return _memory[pc];
    }
}

//0x000 -> 0xFFF
//  The first 512 bytes, from 0x000 to 0x1FF, are where the original interpreter was located, and should not be used by programs.
// 
// Most Chip-8 programs start at location 0x200 (512), but some begin at 0x600 (1536). Programs beginning at 0x600 are intended for the ETI 660 computer.
// 