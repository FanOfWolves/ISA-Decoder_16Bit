using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    class DataTransferType : InstructionType {
        public DataTransferType() {
            base.InstructionTypeID = 0;
            base.opcodeStartBit = 13;
        }
    }
}
