using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    class FlowControlType : InstructionType {
        public FlowControlType() {
            base.InstructionTypeID = 2;
            base.opcodeStartBit = 12;
        }
    }
}
