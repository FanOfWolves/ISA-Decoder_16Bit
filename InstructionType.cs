using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    abstract class InstructionType {
        protected int InstructionTypeID;
        StringBuilder instructionDescription;
        string verb;

        public abstract string DecodeInstruction(int bitInstruction);

        protected abstract void SetOpCode(int bitStream);

        protected abstract void SetFirstOperand(int bitStream);

        protected abstract void SetSecondOperand(int bitStream);

    }
}
