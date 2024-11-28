// http://devernay.free.fr/hacks/chip8/C8TECH10.HTM
namespace Chip8Emulator.Model;

public class CPU
{
    private Registers _registers;
    private OpCode _currentOpCode;
    private OpCode _nextOpCode;

    public CPU()
    {
        _registers = new Registers();
    }
}

public struct Registers
{
    private byte v0;
    private byte v1;
    private byte v2;
    private byte v3;
    private byte v4;
    private byte v5;
    private byte v6;
    private byte v7;
    private byte v8;
    private byte v9;
    private byte vA;
    private byte vB;
    private byte vC;
    private byte vD;
    private byte vE;
    private byte vF;
    private ushort I; // Lowest 12 bits are used
    private byte ST; // Sound Timer
    private byte DT; // Delay Timer
}

/* OpCodes for CHIP8
 * 00E0 - CLS
   00EE - RET
   0nnn - SYS addr
   1nnn - JP addr
   2nnn - CALL addr
   3xkk - SE Vx, byte
   4xkk - SNE Vx, byte
   5xy0 - SE Vx, Vy
   6xkk - LD Vx, byte
   7xkk - ADD Vx, byte
   8xy0 - LD Vx, Vy
   8xy1 - OR Vx, Vy
   8xy2 - AND Vx, Vy
   8xy3 - XOR Vx, Vy
   8xy4 - ADD Vx, Vy
   8xy5 - SUB Vx, Vy
   8xy6 - SHR Vx {, Vy}
   8xy7 - SUBN Vx, Vy
   8xyE - SHL Vx {, Vy}
   9xy0 - SNE Vx, Vy
   Annn - LD I, addr
   Bnnn - JP V0, addr
   Cxkk - RND Vx, byte
   Dxyn - DRW Vx, Vy, nibble
   Ex9E - SKP Vx
   ExA1 - SKNP Vx
   Fx07 - LD Vx, DT
   Fx0A - LD Vx, K
   Fx15 - LD DT, Vx
   Fx18 - LD ST, Vx
   Fx1E - ADD I, Vx
   Fx29 - LD F, Vx
   Fx33 - LD B, Vx
   Fx55 - LD [I], Vx
   Fx65 - LD Vx, [I]
 */

enum OpCode 
{
    
}