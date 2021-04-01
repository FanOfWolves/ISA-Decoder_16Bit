using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    class ArithmeticType : InstructionType {
        public ArithmeticType() {
            base.InstructionTypeID = 1;
            base.opcodeStartBit = 10;
        }
    }
}
