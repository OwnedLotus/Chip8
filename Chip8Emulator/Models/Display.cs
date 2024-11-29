using System;
using System.Numerics;

namespace Chip8Emulator.Models;

public class Display()
{
    UInt64[] _display = new UInt64[32];
    public void ClearDisplay()
    {
        _display = new UInt64[32];
    }

    // Sprite sizes are 8x15 maximum
    public void BufferSprite(Vector2 position, ReadOnlySpan<byte> data)
    {
        // y is depth x is offset
        var offset = (int)(position.X * 8);
        var depth = (int)(position.Y * 5);

        for (int i = 0; i < 5; i++)
            // mast with offset
            _display[depth + i] &= (ulong)(data[i] >> offset); 
    }

    public void DrawDisplay()
    {
        throw new NotImplementedException();
    }
    
    private byte[] Zero =
    [
        0xF0, //11110000
        0x90, //10010000
        0x90, //10010000
        0x90, //10010000
        0xF0, //11110000
    ];

    private byte[] One =
    [
        0x20, // 00100000
        0x60, // 01100000
        0x20, // 00100000
        0x20, // 00100000
        0x70, // 01110000
    ];

    private byte[] Two =
    [
        0xF0, // 11110000
        0x10, // 00010000
        0xF0, // 11110000
        0x80, // 10000000
        0xF0, // 11110000
    ];

    private byte[] Three =
    [
        0xF0,
        0x10,
        0xF0,
        0x10,
        0xF0,
    ];

    private byte[] Four =
    [
        0x90,
        0x90,
        0xF0,
        0x10,
        0x10,
    ];

    private byte[] Five =
    [
        0xF0,
        0x80,
        0xF0,
        0x10,
        0xF0,
    ];

    private byte[] Six =
    [
        0xF0,
        0x80,
        0xF0,
        0x90,
        0xF0,
    ];

    private byte[] Seven =
    [
        0xF0,
        0x10,
        0x20,
        0x40,
        0x40,
    ];
    
    private byte[] Eight =
    [
        0xF0,
        0x90,
        0xF0,
        0x90,
        0xF0,
    ];
    
    private byte[] Nine =
    [
        0xF0,
        0x90,
        0xF0,
        0x10,
        0xF0,
    ];
    
    private byte[] A =
    [
        0xF0,
        0x90,
        0xF0,
        0x90,
        0x90,
    ];

    private byte[] B =
    [
        0xE0,
        0x90,
        0xE0,
        0x90,
        0xE0,
    ];

    private byte[] C =
    [
        0xF0,
        0x80,
        0x80,
        0x80,
        0xF0,
    ];

    private byte[] D =
    [
        0xE0,
        0x90,
        0x90,
        0x90,
        0xE0,
    ];

    private byte[] E =
    [
        0xF0,
        0x80,
        0xF0,
        0x80,
        0xF0,
    ];

    private byte[] F =
    [
        0xF0,
        0x80,
        0xF0,
        0x80,
        0x80,
    ];
    
    
    
}