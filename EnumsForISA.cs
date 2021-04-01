using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    enum ImmediateSwitchEnum {
        immediate = 1,
        register = 0
    }

    enum addressingModesEnum {

    }

    /// <summary>
    /// Used by InstructionType to determine operation
    /// </summary>
    enum opcodeIdentificationHexLiterals {
        hexADD = 0x4000,
        hexADC = 0x6400,
        hexSUB = 0x4400,
        hexMUL = 0x4800,
        hexDIV = 0x4C00,
        hexMOD = 0x5000,
        hexAND = 0x5400,
        hexOR  = 0x5800,
        hexNOT = 0x5C00,
        hexNAND = 0x6000,
        hexJMP = 0x8000,
        hexJC = 0x9000,
        hexCMP= 0xA000,
        hexNOP= 0xB000,
        hexLOAD=0x0000,
        hexSTOR=0x2000
    }

}
