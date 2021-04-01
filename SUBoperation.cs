namespace ISA_Decoder_16Bit {
    class SUBoperation : Operation {
        string verb = "Subtract";

        int operandOneEndBit = 8;
        int operandOneStartBit = 5;
        int operandOneValue;
        string operandOneMeaning;

        int operandTwoEndBit = 4;
        int operandTwoStartBit = 1;
        int operandTwoValue;
        string operandTwoMeaning;

        int immediateSwitchStartBit = 9;
        int immediateSwitchEndBit = 9;
        int immediateSwitchValue;


        public SUBoperation() {

        }

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

        private void DecodeFirstOperand(int inputBits) {
            operandOneValue = inputBits & BitUtilities.CreateBitMask(operandOneStartBit, operandOneEndBit);
            if (operandOneValue < 0 || operandOneValue > 15) {
                operandTwoMeaning = $"OP1: Ya fucke* up";
            }
            else {
                operandOneMeaning = $"r{operandOneValue}";
            }
        }

        private void DecodeSecondOperand(int inputBits) {
            operandTwoValue = inputBits & BitUtilities.CreateBitMask(operandTwoStartBit, operandTwoEndBit);

            // Immediate or Register?
            if (immediateSwitchValue == 0) { // if register
                if (operandTwoValue < 0 || operandTwoValue > 15) {
                    operandTwoMeaning = $"OP2: Ya fucke* up";
                }
                operandTwoMeaning = $"r{operandTwoValue}";
            }
            else {    // else is an immediate
                operandTwoMeaning = $"#{operandTwoValue}";
            }
        }


        /// <summary>
        /// Decode value of the immediateSwitch
        /// </summary>
        /// <param name="inputBits">our instruction</param>
        private void DecodeImmediateSwitch(int inputBits) {
            immediateSwitchValue = inputBits & BitUtilities.CreateBitMask(immediateSwitchStartBit, immediateSwitchEndBit);
        }

        /// <summary>
        /// This bitch looks through ALL our available fields and constructs an English sentence.
        /// </summary>
        private string GetHumanText() {
            return $"{verb} {operandOneMeaning} from {operandTwoMeaning}, store result in {operandOneMeaning}";
        }

    }
}
