﻿// ------------------------------------------------------------------------------------------------------------------------
// File name:       DataTransferType.cs
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
    /// For our data transfer operaations
    /// </summary>
    class DataTransferType : InstructionType {
        public DataTransferType() {
            base.InstructionTypeID = 0;
            base.opcodeStartBit = 13;
        }
    }
}
