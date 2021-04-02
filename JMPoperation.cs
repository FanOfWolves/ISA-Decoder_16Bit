namespace ISA_Decoder_16Bit {
    class JMPoperation: Operation {
        string verb = "Jump";                    // The main verb used for the message

        int operandOneEndBit = 9;               // The end bit of operand one
        int operandOneStartBit = 6;             // The starting bit of operand one
        int operandOneValue;                    // The value of operand one
        string operandOneMeaning;               // The meaning of operand one

        //only two addressing modes, one bit needed
        int addressingModeEndBit = 10;
        int addressingModeStartBit = 10;
        int addressingModeValue;
        string addressingModeMeaning;

        int immediateSwitchStartBit = 11;        // The start bit of the immediate switch
        int immediateSwitchEndBit = 11;          // The end bit of the immediate switch
        int immediateSwitchValue;               // The value of the immediate switch

        int immediateOperandStartBit = 0;       // The start bit for our immediate operand (the 2nd operand)

        public JMPoperation() {

        }

        /// <summary>
        /// Decodes the input bits. This calls all the other functions.
        /// </summary>
        /// <param name="inputBits">a bit stream of the instruction</param>
        /// <returns>a text translation of the instruction</returns>
        public override string DecodeOperation(int inputBits) {
            // Decode Immediate
            DecodeImmediateSwitch(inputBits);

            //grab addressing mode
            DecodeAddressingValue(inputBits);
            // Decode Operand One
            DecodeFirstOperand(inputBits);

            // Decode Operand Two
           // DecodeSecondOperand(inputBits);

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
                operandOneMeaning = $"OP1: Ya messed* up";
            }
            else {
                operandOneMeaning = $"r{operandOneValue}";
            }
        }


        private void DecodeAddressingValue(int inputBits)
        {
            addressingModeValue = inputBits & BitUtilities.CreateBitMask(addressingModeStartBit,addressingModeEndBit);
            switch(addressingModeValue)
            {
                case 0:
                       addressingModeMeaning = "Register Indirect, indexed";
                        break;
                case 1:
                       addressingModeMeaning = "Direct";
                        break;

                default:
                       addressingModeMeaning = "Error, invalid addressing mode.";
                        break;
            }
        }

        /// <summary>
        /// Decode value of the immediateSwitch
        /// </summary>
        /// <param name="inputBits">our instruction</param>
        private void DecodeImmediateSwitch(int inputBits)
        {
            immediateSwitchValue = BitUtilities.MaskInput(inputBits, immediateSwitchStartBit, immediateSwitchEndBit);
        }

        /// <summary>
        /// This badboy    looks through ALL our available fields and constructs an English sentence.
        /// </summary>
        private string GetHumanText() 
        {
           return $"{verb} to a location using {operandOneMeaning}, using the addressing Mode {addressingModeMeaning}";
        }

    }
}
