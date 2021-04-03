// ------------------------------------------------------------------------------------------------------------------------
// File name:       NOPoperation.cs
// Project name:    ISA
// Project description: Decoder for our awesome Detached-Toe 16-bit RISC ISA.
// ------------------------------------------------------------------------------------------------------------------------
// Creator's name and email: Harrison Lee Pollitte. pollitteh@etsu.edu. Edgar Bowlin III, bowline@etsu.edu. nelsondk@etsu.edu 
// Course Name: CSCI-4727 Computer Architecture
// Course Section: 940
// Creation Date: 03/31/2021
// ------------------------------------------------------------------------------------------------------------------------
namespace ISA_Decoder_16Bit {
    /// <summary>
    /// what can you really expect? this just lets the CPU spin.
    /// </summary>
    class NOPoperation: Operation {
        string verb = "NOOP";                    // The main verb used for the message

        int operandOneEndBit = 8;               // The end bit of operand one
        int operandOneStartBit = 5;             // The starting bit of operand one
        int operandOneValue;                    // The value of operand one
        string operandOneMeaning;               // The meaning of operand one

        int operandTwoEndBit = 4;               // The end bit of operand two
        int operandTwoStartBit = 1;             // The start bit of operand two
        int operandTwoValue;                    // The value of operand two
        string operandTwoMeaning;               // The meaning of operand two 

        int immediateSwitchStartBit = 9;        // The start bit of the immediate switch
        int immediateSwitchEndBit = 9;          // The end bit of the immediate switch
        int immediateSwitchValue;               // The value of the immediate switch

        int immediateOperandStartBit = 0;       // The start bit for our immediate operand (the 2nd operand)


        /// <summary>
        /// default constructor
        /// </summary>
        public NOPoperation() {

        }

        /// <summary>
        /// Decodes the input bits. This calls all the other functions.
        /// </summary>
        /// <param name="inputBits">a bit stream of the instruction</param>
        /// <returns>a text translation of the instruction</returns>
        public override string DecodeOperation(int inputBits) {
            // Decode Immediate
            DecodeImmediateSwitch(inputBits);

            // Decode Operand One
            DecodeFirstOperand(inputBits);

            // Decode Operand Two
            DecodeSecondOperand(inputBits);

            // Get readable text
            return GetHumanText();
        }

        /// <summary>
        /// Decode the first operand of this instruction by masking it and 
        /// 1) Determining its value
        /// 2) Assigning it a textual meaning. (FIX THIS)
        /// </summary>
        /// <param name="inputBits">instruction bits</param>
        private void DecodeFirstOperand(int inputBits) {
            operandOneValue = BitUtilities.MaskInput(inputBits, operandOneStartBit, operandOneEndBit);
            if (operandOneValue < 0 || operandOneValue > 15) {
                operandTwoMeaning = $"OP1: Ya messed up";     
            }
            else {
                operandOneMeaning = $"r{operandOneValue}";
            }
        }


        /// <summary>
        /// decode the second operand and get its value and meaning
        /// </summary>
        /// <param name="inputBits">instruction bits</param>
        private void DecodeSecondOperand(int inputBits) {
            // Immediate or Register?
            if(immediateSwitchValue == (int)ImmediateSwitchEnum.immediate) { // This is an immediate value.
                operandTwoValue = BitUtilities.MaskInput(inputBits, immediateOperandStartBit, operandTwoEndBit);
                operandTwoMeaning = $"#{operandTwoValue}";
            }
            else {
                operandTwoValue = BitUtilities.MaskInput(inputBits, operandTwoStartBit, operandTwoEndBit);
                if (operandTwoValue < 0 || operandTwoValue > 15) {
                    operandTwoMeaning = $"OP2: Ya messed up";
                }
                operandTwoMeaning = $"r{operandTwoValue}";
            } 
        }


        /// <summary>
        /// Decode value of the immediateSwitch
        /// </summary>
        /// <param name="inputBits">our instruction</param>
        private void DecodeImmediateSwitch(int inputBits) {
            immediateSwitchValue = BitUtilities.MaskInput(inputBits, immediateSwitchStartBit, immediateSwitchEndBit);
        }

        /// <summary>
        /// This badboy    looks through ALL our available fields and constructs an English sentence.
        /// </summary>
        private string GetHumanText() {
            return $"NO operation was specifically specified.";
        }

    }
}
