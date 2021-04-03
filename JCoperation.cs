// ------------------------------------------------------------------------------------------------------------------------
// File name:       JCoperation
// Project name:    ISA
// Project description: Decoder for our awesome Detached-Toe 16-bit RISC ISA.
// ------------------------------------------------------------------------------------------------------------------------
// Creator's name and email: Harrison Lee Pollitte. pollitteh@etsu.edu. Edgar Bowlin III, bowline@etsu.edu., David Nelson nelsondk@etsu.edu , Michael Edwards edwardsmr@etsu.edu
// Course Name: CSCI-4727 Computer Architecture
// Course Section: 940
// Creation Date: 03/31/2021
// ------------------------------------------------------------------------------------------------------------------------
namespace ISA_Decoder_16Bit {

    /// <summary>
    /// A one-operand operation that jumps if a condition is met.
    /// </summary>
    class JCoperation: Operation {
        string verb = "Conditional Jump";       // The main verb used for the message

        int operandOneStartBit = 4;             // The starting bit of operand one
        int operandOneEndBit = 7;               // The end bit of operand one
        int operandOneValue;                    // The value of operand one
        string operandOneMeaning;              

        string addressingModeMeaning;           // A string of the addressing mode

        int negativeBit = 10;                   // Location of the bit used for negative/positive
        int negativeBitValue = 0;               // 0 == Positive. 1 == Negative
        string negativeBitMeaning;

        int conditionalStartBit = 8;
        int conditionalEndBit = 9;              
        int conditionalValue;                   // The integer value of the conditional
        string conditionalMeaning;              // The string of the meaning of the conditional

        int immediateSwitchStartBit = 11;       // The start bit of the immediate switch
        int immediateSwitchEndBit = 11;         // The end bit of the immediate switch
        int immediateSwitchValue;               // The value of the immediate switch

        int immediateOperandStartBit = 0;       // The start bit for our immediate operand (the 2nd operand)
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public JCoperation() {
        }

        /// <summary>
        /// Decodes the input bits. This calls all the other functions.
        /// </summary>
        /// <param name="inputBits">a bit stream of the instruction</param>
        /// <returns>a text translation of the instruction</returns>
        public override string DecodeOperation(int inputBits) {      
            DecodeImmediateSwitch(inputBits);  // Decode Immediate
            DecodeFirstOperand(inputBits);     // Decode Operand One
            DecodeNegativeBit(inputBits);      // Decode negative
            DecodeConditionalValue(inputBits); // decode conditional Value
            return GetHumanText();             // Get readable text
        }

        /// <summary>
        /// Decodes the valuie at the negative bit.
        /// </summary>
        /// <param name="inputBits">bits to be used.</param>
        private void DecodeNegativeBit(int inputBits) {
            negativeBitValue = BitUtilities.MaskInput(inputBits, negativeBit, negativeBit); // Get value from negative bit.
            if (negativeBitValue == 0) 
                negativeBitMeaning = "+";
            else negativeBitMeaning = "-";
        }


        /// <summary>
        /// Decode the first operand of this instruction by masking it and 
        /// 1) Determining its value
        /// 2) Assigning it a textual meaning. (FIX THIS)
        /// </summary>
        /// <param name="inputBits">instruction bits</param>
        private void DecodeFirstOperand(int inputBits) {
            if (immediateSwitchValue == (int)ImmediateSwitchEnum.immediate) { // This is an immediate value.
                operandOneValue = BitUtilities.MaskInput(inputBits, immediateOperandStartBit, operandOneEndBit);
                operandOneMeaning = $"{operandOneValue}";
            }
            else { // this is a register value
                operandOneValue = BitUtilities.MaskInput(inputBits, operandOneStartBit, operandOneEndBit);  // mask it
                if (operandOneValue < 0 || operandOneValue > 15)                    // is it one of our general registers?
                    throw new System.Exception("Bad Operand One!");                 // if not, BAD
                operandOneMeaning = $"r{operandOneValue}";
            }
        }

        /// <summary>
        /// Decodes the conditional that we look for with this statement.
        /// </summary>
        /// <param name="inputBits">instruction bits</param>
        private void DecodeConditionalValue(int inputBits)
        {
            conditionalValue = BitUtilities.MaskInput(inputBits, conditionalStartBit, conditionalEndBit);

            switch(conditionalValue) {
                case 0: conditionalMeaning = "Equal to"; break;
                case 1: conditionalMeaning = "Not Equal to"; break;
                case 2: conditionalMeaning = "greater than"; break;
                case 3: conditionalMeaning = "less than"; break;
                case 4: conditionalMeaning = "above or equal to"; break;
                case 5: conditionalMeaning = "Below or equal to"; break;
				default: throw new System.Exception("Invalid Conditional!");
            }
        }

        /// <summary>
        /// Decode value of the immediateSwitch
        /// </summary>
        /// <param name="inputBits">our instruction</param>
        private void DecodeImmediateSwitch(int inputBits)
        {
            immediateSwitchValue = BitUtilities.MaskInput(inputBits, immediateSwitchStartBit, immediateSwitchEndBit);
            if (immediateSwitchValue == 0) // if using register, this is an indirect index reference
                addressingModeMeaning = "an Indexed Indirect Register";
            else
                addressingModeMeaning = "a direct address.";
        }

        /// <summary>
        /// This badboy looks through ALL our available fields and constructs an English sentence.
        /// </summary>
        private string GetHumanText() {
            if (immediateSwitchValue == (int)ImmediateSwitchEnum.immediate) // if an immediate, use the negative bit
                return $"If flags correspond to conditional {conditionalMeaning}, then {verb} {negativeBitMeaning}{operandOneMeaning} bytes.";        
          return $"If flags correspond to conditional \"{conditionalMeaning}\", then {verb} to the location specified using {operandOneMeaning} as {addressingModeMeaning}";
        }
    }
}
