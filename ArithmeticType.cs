using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    class ArithmeticType : InstructionType {
        int InstructionTypeID = 1;




        public override string DecodeInstruction(int bitInstruction) {
            throw new NotImplementedException();
        }

        internal override void SetOpCode() {

        }
    }
}
