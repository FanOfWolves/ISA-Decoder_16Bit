namespace ISA_Decoder_16Bit {
    class LOADoperation: Operation {
        string verb = "Load";                    // The main verb used for the message

        int operandOneEndBit = 11;               // The end bit of operand one
        int operandOneStartBit = 8;             // The starting bit of operand one
        int operandOneValue;                    // The value of operand one
        string operandOneMeaning;               // The meaning of operand one

        int operandTwoEndBit = 7;               // The end bit of operand two
        int operandTwoStartBit = 4;             // The start bit of operand two
        int operandTwoValue;                    // The value of operand two
        string operandTwoMeaning;               // The meaning of operand two 

        int addressingModeEndBit = 12;
        int addressingModeStartBit = 11;
        int addressingModeValue;
        string addressingModeMeaning;

        int immediateSwitchStartBit = 10;        // The start bit of the immediate switch
        int immediateSwitchEndBit = 10;          // The end bit of the immediate switch
        int immediateSwitchValue;               // The value of the immediate switch

        int immediateOperandStartBit = 0;       // The start bit for our immediate operand (the 2nd operand)

        public LOADoperation() {

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

            DecodeAddressingValue(inputBits);

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
                operandTwoMeaning = $"OP1: Ya messed* up";
            }
            else {
                operandOneMeaning = $"r{operandOneValue}";
            }
        }

        private void DecodeSecondOperand(int inputBits) {
            // Immediate or Register?
            if(immediateSwitchValue == (int)ImmediateSwitchEnum.immediate) { // This is an immediate value.
                operandTwoValue = BitUtilities.MaskInput(inputBits, immediateOperandStartBit, operandTwoEndBit);
                operandTwoMeaning = $"#{operandTwoValue}";
            }
            else {
                operandTwoValue = BitUtilities.MaskInput(inputBits, operandTwoStartBit, operandTwoEndBit);
                if (operandTwoValue < 0 || operandTwoValue > 15) {
                    operandTwoMeaning = $"OP2: Ya messed* up";
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

        private void DecodeAddressingValue(int inputBits)
        {
            addressingModeValue = BitUtilities.MaskInput(inputBits, addressingModeStartBit, addressingModeEndBit);
            switch (addressingModeValue)
            {
                case 1:
                    addressingModeMeaning = "immediate";
                    break;
                case 0:
                    addressingModeMeaning = "register indirect, indexed";
                    break;
                case 2:
                    addressingModeMeaning = "direct";
                    break;
                case 3:
                    addressingModeMeaning = "Error, invalid addressing mode.";
                    break;
            }
        }





        /// <summary>
        /// This badboy looks through ALL our available fields and constructs an English sentence.
        /// </summary>
        private string GetHumanText() {
            return $"{verb} {operandTwoMeaning} into {operandOneMeaning}, using the addressing mode {addressingModeMeaning}";
        }

    }
}
