﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    class FlowControlType : InstructionType {
        int InstructionTypeID = 2;

        public override string DecodeInstruction(int bitInstruction) {
            throw new NotImplementedException();
        }
    }
}
