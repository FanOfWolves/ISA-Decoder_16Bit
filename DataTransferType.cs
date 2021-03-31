using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    class DataTransferType : InstructionType {
        InstructionTypeID = 0;
        StringBuilder instructionDescription;
        string verb;
        
        
        int opCode;
        int RegRegState;
        int operandOne;
        int operandTwo;


        int opCodeLength = 1;
        int opCodeStartBit = 13;
        int opCodeEndBit = 13;
        int operandOneStartBit = 8;
        int operandOneEndBit = 11;
        int immediateSwitch = 12;
        int operandTwoStartBit = 4;
        int operandTwoEndBit = 7;
        


        int hexLOAD = 0x0000;
        int hexSTOR = 0x2000;
        int hexSwitchset = 0x1000;
        public override string DecodeInstruction(int bitInstruction) {
            // Determine OpCode
            SetOpCode(bitInstruction);

            // Check Reg-Reg Bit
            SetRegRegState(bitInstruction);

            // Check operands
            SetFirstOperand(bitInstruction);
            SetSecondOperand(bitInstruction);


            // Determine 


            // Finally, using class specific syntax, return a formatted string
            // detailing the instruction in english.
            return this.instructionDescription.ToString();
        }
        
        protected void SetRegRegState(int bitStream) {
            // Mask RegRegBit
            int maskedInput = bitStream & BitUtilities.CreateBitMask(immediateSwitch, immediateSwitch);

            // Set RegRegBit
            RegRegState = maskedInput;
        }

        protected override void SetFirstOperand(int bitStream) {
            int maskedInput;
            //LOAD 
            if(opCode == hexLOAD) {
                // First operand is always a register ID.
                operandOne = bitStream & BitUtilities.CreateBitMask(operandOneStartBit, operandOneEndBit);
            }

            //STOR
            else {
                // First operand (a) register ID or (b) indirect register address

            }
        }
        protected override void SetSecondOperand(int bitStream) {
            throw new NotImplementedException();
        }

        protected override void SetOpCode(int bitStream) {
            // Mask OpCode
            int maskedInput = bitStream & BitUtilities.CreateBitMask(opCodeStartBit, opCodeEndBit);

            // Set opCode and instruction verb
            if (maskedInput == hexLOAD) {
                verb = "Load ";
                opCode = hexLOAD;
            }
            else if (maskedInput == hexSTOR) {
                verb = "Store ";
                opCode = hexSTOR;
            }
            else {
                throw new NotSupportedException();
            }
        }


    }
}
