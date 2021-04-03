namespace ISA_Decoder_16Bit
{
    class NOToperation : Operation
    {
        string verb = "Negate";                    // The main verb used for the message

        int operandOneEndBit = 9;               // The end bit of operand one
        int operandOneStartBit = 6;             // The starting bit of operand one
        int operandOneValue;                    // The value of operand one
        string operandOneMeaning;               // The meaning of operand one

        public NOToperation() {

        }

        /// <summary>
        /// Decodes the input bits. This calls all the other functions.
        /// </summary>
        /// <param name="inputBits">a bit stream of the instruction</param>
        /// <returns>a text translation of the instruction</returns>
        public override string DecodeOperation(int inputBits)
        {
            // Decode Operand One
            DecodeFirstOperand(inputBits);

            // Get readable text
            return GetHumanText();
        }

        /// <summary>
        /// Decode the first operand of this instruction by masking it and 
        /// 1) Determining its value
        /// 2) Assigning it a textual meaning. (FIX THIS)
        /// </summary>
        /// <param name="inputBits">instruction bits</param>
        private void DecodeFirstOperand(int inputBits)
        {
            operandOneValue = BitUtilities.MaskInput(inputBits, operandOneStartBit, operandOneEndBit);
            if (operandOneValue < 0 || operandOneValue > 15) {
                operandOneMeaning = $"OP1: Ya messed up";
            }
            else {
                operandOneMeaning = $"r{operandOneValue}";
            }
        }

        /// <summary>
        /// This badboy looks through ALL our available fields and constructs an English sentence.
        /// </summary>
        private string GetHumanText() {
            return $"{verb} {operandOneMeaning} and store in {operandOneMeaning}";
        }

    }
}
