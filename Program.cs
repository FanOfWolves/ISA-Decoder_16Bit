// ------------------------------------------------------------------------------------------------------------------------
// File name:       Program.cs
// Project name:    ISA
// Project description: Decoder for our awesome Detached-Toe 16-bit RISC ISA.
// ------------------------------------------------------------------------------------------------------------------------
// Creator's name and email: Harrison Lee Pollitte. pollitteh@etsu.edu. Edgar Bowlin III, bowline@etsu.edu. nelsondk@etsu.edu
// Course Name: CSCI-4727 Computer Architecture
// Course Section: 940
// Creation Date: 03/31/2021
// ------------------------------------------------------------------------------------------------------------------------
using System;

namespace ISA_Decoder_16Bit {
    class Program {
        static void Main() {
            // Read Input
            String hexinput = "0000";
            int binaryInput;

            while (true) {
                Console.WriteLine("Input a 4-digit hex string or \"XXXX\" to exit.\n");
                // Read input
                hexinput = Console.ReadLine();
                // Convert Input to unsigned 16-bit integer
                try {
                    // Exit on EXIT CODE
                    if (hexinput.ToUpper() == "XXXX") { 
                        Console.WriteLine("Program exited.");
                        break;
                    }
                    binaryInput = Convert.ToInt32(hexinput, 16);
                    //Check if larger than Uint16... (i.e. not a 16bit)
                    if (binaryInput > ushort.MaxValue) {
                        throw new Exception("Input cannot be greater than an unsigned short.");
                    }

                    // Else decode input
                    string output = DecodeInput(binaryInput);

                    // Display output
                    Console.WriteLine(output);
                }
                catch (Exception e) {
                    Console.WriteLine($"Could not read input '{hexinput}': {e.Message}");
                }
            }
        }

        /// <summary>
        /// Decode the input from the user.
        /// </summary>
        /// <param name="input">from user</param>
        /// <returns>a string representing a human-readable text translation of the machine code read and translated by the ISA architecture.</returns>
        private static string DecodeInput(int input) {

            InstructionType ourInstruction = null;

            // I Check instruction type (Bits 14-15)
            // I.A SHOW bits 14-15
            int bitmask = BitUtilities.CreateBitMask(14, 15); //1100 0000 0000
            int maskedinput = input & bitmask;
            switch (maskedinput) {
                case 0x0000:    //00 - data transfer
                    ourInstruction = new DataTransferType();
                    break;
                case 0x4000:    //01 - arithmetic/logical
                    ourInstruction = new ArithmeticType();
                    break;
                case 0x8000:    //10 - flow control
                    ourInstruction = new FlowControlType();
                    break;
                default:
                    return "Invalid Instruction Type!";
            }

            try {
                // Decode input
                string output = ourInstruction.DecodeInstruction(input);
                return output;
            }
            // Oh no! Something went a wrong!
            catch (Exception e) {
                return $"{e.Message} You dun messed up.";
            }
        }
    } 
}