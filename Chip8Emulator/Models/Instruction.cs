namespace Chip8Emulator.Models;

public struct Instruction
{
  public OpCode OpCode { get; init; }
  
  public byte Operand1 { get; init; }
  public byte Operand2 { get; init; }
  public byte Operand3 { get; init; }
}
public enum OpCode
{
  CLS, //00E0
  RET, //00EE
  SYSA, //0nnn
  JPA, //1nnn
  CALLA, //2nnn
  SEVXb, //3xkk
  SNEXb, //4xkk
  SEXY, //5xy0
  LDXB, //6xkk
  ADDXB, //7xkk
  LDXY, //8xy0
  LDOXY, //8xy1 OR vx vy
  ANDXY, //8xy2 AND vx vy
  XORXY, //8xy3 XOR vx vy
  ADDXY, //8xy4
  SUBXY, //8xy5
  SHRXY, //8xy6
  SUBNXY, //8xy7
  SHLXY, //8xyE
  SNEXY, //9xy0
  LDIA, //Annn
  JP0A, //Bnnn
  RNDXB, //Cxkk
  DRWXY, //Dxyn nibble
  SKPX, //Ex9E
  SKNPX, //ExA1
  LDXD, //Fx07
  LDXK, //Fx0A
  LDDX, //Fx15
  LDSX, //Fx18
  ADDIX, //Fx1E
  LDFX, //Fx29
  LDBX, //Fx33
  LDIX, //Fx55
  LDXI, //Fx65
     
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