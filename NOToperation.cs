﻿// ------------------------------------------------------------------------------------------------------------------------
// File name:       NOToperation.cs
// Project name:    ISA
// Project description: Decoder for our awesome Detached-Toe 16-bit RISC ISA.
// ------------------------------------------------------------------------------------------------------------------------
// Creator's name and email: Harrison Lee Pollitte. pollitteh@etsu.edu. Edgar Bowlin III, bowline@etsu.edu. nelsondk@etsu.edu 
// Course Name: CSCI-4727 Computer Architecture
// Course Section: 940
// Creation Date: 03/31/2021
// ------------------------------------------------------------------------------------------------------------------------
namespace ISA_Decoder_16Bit
{

    /// <summary>
    /// one operand instruction that negates the value in operand 1 and store it into operand 1 
    /// </summary>
    class NOToperation : Operation
    {
        string verb = "Negate";                    // The main verb used for the message

        int operandOneEndBit = 9;               // The end bit of operand one
        int operandOneStartBit = 6;             // The starting bit of operand one
        int operandOneValue;                    // The value of operand one
        string operandOneMeaning;               // The meaning of operand one


        /// <summary>
        /// default constructor
        /// </summary>
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
