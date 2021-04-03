namespace ISA_Decoder_16Bit {
    class JCoperation: Operation {
        string verb = "Conditional Jump";                    // The main verb used for the message

        int operandOneEndBit = 6;               // The end bit of operand one
        int operandOneStartBit = 3;             // The starting bit of operand one
        int operandOneValue;                    // The value of operand one
        string operandOneMeaning;               // The meaning of operand one

        string addressingModeMeaning;

        int conditionalEndBit = 9;
        int conditionalStartBit = 7;
        int conditionalValue;
        string conditionalMeaning;

        int immediateSwitchStartBit = 11;       // The start bit of the immediate switch
        int immediateSwitchEndBit = 11;         // The end bit of the immediate switch
        int immediateSwitchValue;               // The value of the immediate switch

        int immediateOperandStartBit = 0;       // The start bit for our immediate operand (the 2nd operand)
        
        public JCoperation() {

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
            // decode conditional Value
            DecodeConditionalValue(inputBits);

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
            if (immediateSwitchValue == (int)ImmediateSwitchEnum.immediate) { // This is an immediate value.
                operandOneValue = BitUtilities.MaskInput(inputBits, immediateOperandStartBit, operandOneEndBit);
                operandOneMeaning = $"#{operandOneValue}";
            }
            else {
                operandOneValue = BitUtilities.MaskInput(inputBits, operandOneStartBit, operandOneEndBit);
                if (operandOneValue < 0 || operandOneValue > 15)
                    throw new System.Exception("Bad Operand One!");
                operandOneMeaning = $"r{operandOneValue}";
            }
        }


        private void DecodeConditionalValue(int inputBits)
        {
            conditionalValue = inputBits & BitUtilities.CreateBitMask(conditionalStartBit,conditionalEndBit);

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
          return $"If flags correspond to conditional {conditionalMeaning}, then {verb} to the location specified using {operandOneMeaning} as {addressingModeMeaning}";
        }
    }
}
