namespace ISA_Decoder_16Bit {
    class CMPoperation: Operation {
        string verb = "Compare";                    // The main verb used for the message

        int operandOneEndBit = 9;               // The end bit of operand one
        int operandOneStartBit = 6;             // The starting bit of operand one
        int operandOneValue;                    // The value of operand one
        string operandOneMeaning;               // The meaning of operand one

        int operandTwoEndBit = 5;               // The end bit of operand two
        int operandTwoStartBit = 2;             // The start bit of operand two
        int operandTwoValue;                    // The value of operand two
        string operandTwoMeaning;               // The meaning of operand two 

//only two addressing modes, one bit needed

        int immediateSwitchStartBit = 11;        // The start bit of the immediate switch
        int immediateSwitchEndBit = 11;          // The end bit of the immediate switch
        int immediateSwitchValue;               // The value of the immediate switch
        string immediateSwitchMeaning;

        int immediateOperandStartBit = 0;       // The start bit for our immediate operand (the 2nd operand)

        public CMPoperation() {

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
            operandOneValue = inputBits & BitUtilities.CreateBitMask(operandOneStartBit, operandOneEndBit);
            if (operandOneValue < 0 || operandOneValue > 15) {
                operandTwoMeaning = $"OP1: Ya messed up";     
            }
            else {
                operandOneMeaning = $"r{operandOneValue}";
            }
        }

        private void DecodeSecondOperand(int inputBits) {
            // Immediate or Register?
            if(immediateSwitchValue == (int)ImmediateSwitchEnum.immediate) { // This is an immediate value.
                operandTwoValue = inputBits & BitUtilities.CreateBitMask(immediateOperandStartBit, operandTwoEndBit);
                operandTwoMeaning = $"#{operandTwoValue}";
            }
            else {
                operandTwoValue = inputBits & BitUtilities.CreateBitMask(operandTwoStartBit, operandTwoEndBit);
                if (operandTwoValue < 0 || operandTwoValue > 15) {
                    operandTwoMeaning = $"OP2: Ya Done Goofed";
                }
                operandTwoMeaning = $"r{operandTwoValue}";
            } 
        }


        /// <summary>
        /// Decode value of the immediateSwitch
        /// </summary>
        /// <param name="inputBits">our instruction</param>
        private void DecodeImmediateSwitch(int inputBits) {
            immediateSwitchValue = inputBits & BitUtilities.CreateBitMask(immediateSwitchStartBit, immediateSwitchEndBit);
            if(immediateSwitchValue == (int)ImmediateSwitchEnum.register) {
                immediateSwitchMeaning = "Register";
			}else {
                immediateSwitchMeaning = "Immediate";
			}
        }

        /// <summary>
        /// This badboy    looks through ALL our available fields and constructs an English sentence.
        /// </summary>
        private string GetHumanText() {
            return $"{verb} {operandOneMeaning} to {operandTwoMeaning}, treating the second operand as {immediateSwitchMeaning}";
        }

        
    }
}
