// ------------------------------------------------------------------------------------------------------------------------
// File name:       SUBoperation.cs
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
    /// two operand operation that subtracts operand 2 from operand 1 and stores it in operand 1
    /// </summary>
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

        /// <summary>
        /// default constructor
        /// </summary>
        public SUBoperation() {

        }

        /// <summary>
        /// used to decode the operation and provide a human readable string.
        /// </summary>
        /// <param name="inputBits"></param>
        /// <returns></returns>
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
        /// used to decode the first operand and get its meaning and value
        /// </summary>
        /// <param name="inputBits"></param>
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
        /// used to decode the second operand and get its meaning and value
        /// </summary>
        /// <param name="inputBits">instruction bits</param>
        private void DecodeSecondOperand(int inputBits) {
            operandTwoValue = BitUtilities.MaskInput(inputBits, operandTwoStartBit, operandTwoEndBit);

            // Immediate or Register?
            if (immediateSwitchValue == 0) { // if register
                if (operandTwoValue < 0 || operandTwoValue > 15)
                { //used to check if valid register
                    operandTwoMeaning = $"OP2: Ya messed up";
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
            immediateSwitchValue = BitUtilities.MaskInput(inputBits, immediateSwitchStartBit, immediateSwitchEndBit);
        }

        /// <summary>
        /// This badboy    looks through ALL our available fields and constructs an English sentence.
        /// </summary>
        private string GetHumanText() {
            return $"{verb} {operandOneMeaning} from {operandTwoMeaning}, store result in {operandOneMeaning}";
        }

    }
}
