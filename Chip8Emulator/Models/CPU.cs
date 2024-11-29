// http://devernay.free.fr/hacks/chip8/C8TECH10.HTM

using System;
using System.Collections.Generic;

namespace Chip8Emulator.Models;

public class Cpu()
{
    private Registers _registers = new();
    private ushort _opcode = 0x0000;
    private byte _keyboardKey = 0xFF; // Max value is no input
    private SoundTimer _soundTimer = new();
    private DelayTimer _delayTimer = new();
    private Stack<ushort> _addressStack = new();
    private Memory _memory;

    public void Tick()
    {
        _delayTimer.Tick();
        _soundTimer.Tick();
    }

    public void ReadKey(byte key)
    {
        _keyboardKey = key;
    }

    public void ReadOpCode(ushort opcode)
    {
        _opcode = opcode;
    }

    public void ExecuteInstruction()
    {
        byte x = (byte)((_opcode & 0x0F00) >> 8);
        byte y = (byte)((_opcode & 0x00F0) >> 4);
        byte kk = (byte)(_opcode & 0x00FF);
        ushort nnn = (ushort)(_opcode & 0x0FFF);
        byte n = (byte)(_opcode & 0x000F);

        switch (_opcode & 0xF000)
        {
            case 0x0000:
                if (_opcode == 0x00E0)
                {
                    // CLS
                    throw new NotImplementedException();
                    break;
                } 
                else if (_opcode == 0x00EE)
                {
                    // RET
                    // pc = stack.Pop();
                    _registers.PC = _addressStack.Pop();
                    break;
                }
                else
                {
                    // SYSA
                    throw new NotImplementedException();
                break;
                }
            case 0x1000:
                //jpa
                //cp = nnn
                break;
            case 0x2000:
                // CALLA
                //stack.push(pc)
                //pc = nnn
                _addressStack.Push(_registers.PC);
                _registers.PC = nnn;
                break;
            case 0x3000:
                // SEVXB
                // if(V[x] == kk) pc += 2
                if (_registers.v[x] == kk) _registers.PC += 2; 
                break;
            case 0x4000:
                // SNEXB
                // if(V[x] != kk) pc += 2
                if (_registers.v[x] != kk) _registers.PC += 2;
                break;
            case 0x5000:
                // SEXY
                // if (v[x] != v[y]) pc += 2
                break;
            case 0x6000:
                // LDXB
                // V[x] == kk
                break;
            case 0x7000:
                // ADDXB
                // V[x] += KK
                break;
            case 0x8000:
                switch (n)
                {
                    case 0x0:
                        // LDXY
                        // v[x] = v[y]
                        break;
                    case 0x1:
                        // LDOXY (OR vx vy) V[x] |= V[y];
                        break; 
                    case 0x2: // ANDXY V[x] &= V[y];
                        break; 
                    case 0x3: // XORXY V[x] ^= V[y];
                        break; 
                    case 0x4: // ADDXY ushort sum = (ushort)(V[x] + V[y]); V[0xF] = (byte)(sum > 255 ? 1 : 0); // Set carry flag V[x] = (byte)sum;
                              break; 
                    case 0x5: // SUBXY V[0xF] = (byte)(V[x] > V[y] ? 1 : 0); // Set borrow flag V[x] -= V[y];
                        break; 
                    case 0x6: // SHRXY V[0xF] = (byte)(V[x] & 0x1); // Store least significant bit in VF V[x] >>= 1;
                        break; 
                    case 0x7: // SUBNXY V[0xF] = (byte)(V[y] > V[x] ? 1 : 0); // Set borrow flag V[x] = (byte)(V[y] - V[x]);
                        break; 
                    case 0xE: // SHLXY V[0xF] = (byte)(V[x] >> 7); // Store most significant bit in VF V[x] <<= 1;
                        break;
                }
                break;
            case 0x9000:
                // SNEXY
                // if(v[x] != v[y]) += 2
                break;
            case 0xA000:
                // LDIA
                // I = nnn;
                break;
            case 0xB000:
                // JP0A
                //pc = (ushort)(v[0] + nnn)
                break;
            case 0xC000:
                // RNDXB
                // v[x] = (byte)(new Random().Next(256) & kk)
                break;
            case 0xD000:
                // DRWXY (nibble )
            break;
            case 0xE000:
                if (kk == 0x9E)
                {
                    //SKPX
                    // Implement Key Press
                }
                else if (kk == 0xA1)
                {
                    // SKNP
                    // Implement Key not pressed check
                }
                break;
            case 0xF000:
                switch (kk)
                {
                    case 0x07:
                        // LDXD
                        // v[x] = delayTimer;
                        break;
                    case 0x0A:
                        // LDXK
                        // Implement Key press wait
                        break;
                    case 0x15:
                        // LDDX
                        // delayTimer = v[x]
                        break;
                    case 0x18:
                        // LDSX
                        // soundTimer = v[x]
                        break;
                    case 0x1E:
                        // ADDIX
                        //I += v[x]
                        break;
                    case 0x29:
                        // LDFX
                        // Implement setting I to font character
                        break;
                    case 0x33:
                        // LDBX
                        // Implement storing BCD representation
                        break;
                    case 0x55:
                        // LDIX
                        // for (int i = 0; i <= x; i++) memory[I + i] = V[i]
                        break;
                    case 0x65:
                        // LDXI
                        // for(int i = 0; i <= x; i++) v[i] = (byte)memory[I + i]
                        break;
                }
                break;
            default:
                throw new InvalidOperationException($"Unknown opcode: 0x{_opcode:X}");
        }
    }
}

public struct Registers()
{
    public byte[] v = new byte[0xF];
    
    public ushort I { get; set; } = ushort.MinValue;
    public byte SP { get; set; } = Byte.MinValue;
    public ushort PC { get; set; } = ushort.MinValue;
    
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