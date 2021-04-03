// ------------------------------------------------------------------------------------------------------------------------
// File name:       EnumForISA.cs
// Project name:    ISA
// Project description: Decoder for our awesome Detached-Toe 16-bit RISC ISA.
// ------------------------------------------------------------------------------------------------------------------------
// Creator's name and email: Harrison Lee Pollitte. pollitteh@etsu.edu. Edgar Bowlin III, bowline@etsu.edu., David Nelson nelsondk@etsu.edu , Michael Edwards edwardsmr@etsu.edu
// Course Name: CSCI-4727 Computer Architecture
// Course Section: 940
// Creation Date: 03/31/2021
// ------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    /// <summary>
    /// Used by operations for their immediates.
    /// </summary>
    enum ImmediateSwitchEnum {
        immediate = 1,
        register = 0
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
