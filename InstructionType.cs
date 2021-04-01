using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    abstract class InstructionType {
        protected int InstructionTypeID;
        protected int opcodeStartBit;
        protected int opcodeEndBit;
        protected int opcode;
        protected Operation operation;
        protected List<int> availableOpcodes;

        public string DecodeInstruction(int bitInstruction) {
            // (1) Determine opcode
            DecodeOpcode(bitInstruction);


        }

        protected Operation DecodeOpcode(int bitInstruction) {
            // Get mask for opcode.
            opcode = bitInstruction & BitUtilities.CreateBitMask(opcodeStartBit, opcodeEndBit);
        }

        public abstract void PopulateOpcodeList();
    }
}
