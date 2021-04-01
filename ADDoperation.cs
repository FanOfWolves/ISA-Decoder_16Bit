using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    class ADDoperation : TwoOperandOperation, ImmediateOperation {

        public ADDoperation() {
            this.operandOneEndBit;
        }

        public override void DecodeFirstOperand(int bitStream) {
            throw new NotImplementedException();
        }

        public override string DecodeOperation() {
            throw new NotImplementedException();
        }

        public override void DecodeSecondOperand(int bitStream) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decode value of the immediateSwitch.
        /// </summary>
        /// <param name="instructionBits">our instruction</param>
        public override void DecodeImmediateSwitch(int instructionBits) {

        }

    }
}
