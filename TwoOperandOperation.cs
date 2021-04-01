using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    abstract class TwoOperandOperation: Operation {
        protected int operandOneValue;
        protected int operandTwoValue;
        protected int operandOneStartBit;
        protected int operandOneEndBit;
        protected int operandTwoStartBit;
        protected int operandTwoEndBit;

        public abstract void DecodeFirstOperand(int bitStream);

        public abstract void DecodeSecondOperand(int bitStream);

    }
}