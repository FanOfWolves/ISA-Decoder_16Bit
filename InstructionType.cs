using System.Collections.Generic;

namespace ISA_Decoder_16Bit {
    abstract class InstructionType {
        protected int InstructionTypeID;
        protected int opcodeStartBit;
        protected int opcode;
        protected Operation operation;

        public string DecodeInstruction(int inputBits) {
            // (1) Determine opcode
            operation = DecodeOpcode(inputBits);

            // (2) Decode operation and get text.
            return operation.DecodeOperation(inputBits);

        }

        public Operation DecodeOpcode(int inputBits) {
            // Get mask for opcode + InstructionID
            opcode = inputBits & BitUtilities.CreateBitMask(opcodeStartBit, 15);

            switch (opcode) {
                case (int)opcodeIdentificationHexLiterals.hexADD:
                    return new ADDoperation();
                case (int)opcodeIdentificationHexLiterals.hexADC:
                    return new ADCoperation();
                case (int)opcodeIdentificationHexLiterals.hexSUB:
                    return new SUBoperation();
                case (int)opcodeIdentificationHexLiterals.hexMUL:
                    return new MULoperation();
                case (int)opcodeIdentificationHexLiterals.hexDIV:
                    return new DIVoperation();
                case (int)opcodeIdentificationHexLiterals.hexMOD:
                    return new MODoperation();
                case (int)opcodeIdentificationHexLiterals.hexAND:
                    return new ANDoperation();
                case (int)opcodeIdentificationHexLiterals.hexOR:
                    return new ORoperation();
                case (int)opcodeIdentificationHexLiterals.hexNOT:
                    return new NOToperation();
                case (int)opcodeIdentificationHexLiterals.hexNAND:
                    return new NANDoperation();
                case (int)opcodeIdentificationHexLiterals.hexJMP:
                    return new JMPoperation();
                case (int)opcodeIdentificationHexLiterals.hexJC:
                    return new JCoperation();
                case (int)opcodeIdentificationHexLiterals.hexCMP:
                    return new CMPoperation();
                case (int)opcodeIdentificationHexLiterals.hexNOP:
                    return new NOPoperation();
                case (int)opcodeIdentificationHexLiterals.hexLOAD:
                    return new LOADoperation();
                case (int)opcodeIdentificationHexLiterals.hexSTOR:
                    return new STORoperation();
                default:
                    return null;
            }
        }
    }
}
