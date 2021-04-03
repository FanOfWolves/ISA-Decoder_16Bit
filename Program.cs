/// 
/// 
///
using System;

namespace ISA_Decoder_16Bit {
    class Program {
        static void Main() {
            // Read Input
            String hexinput = "0000";
            int binaryInput;

            while (true) {
                Console.WriteLine("Input a 4-digit hex string or \"XXXX\" to exit.\n");
                hexinput = Console.ReadLine();

                // Convert Input to unsigned 16-bit integer
                //binaryInput = Convert.ToUInt16(hexinput, 16);   // [TODO]: Convert to UInt16.TryParse()

                try
                {
                    if (hexinput.ToUpper() == "XXXX")
                    {
                        Console.WriteLine("Program exited.");
                        break;
                    }

                    binaryInput = Convert.ToInt32(hexinput, 16);

                    //Check if larger than Uint16...
                    if (binaryInput > ushort.MaxValue)
                    {
                        throw new Exception("Input cannot be greater than an unsigned short.");
                    }

                    // Break condition: end program on 0x0000
                    if (binaryInput == 0) {
                        Console.WriteLine("Smell you later.\n");
                        System.Environment.Exit(0);
                    }

                    // Else decode input
                    string output = DecodeInput(binaryInput);

                    // Display output
                    Console.WriteLine(output);
                }
                catch (Exception e)
                {

                    Console.WriteLine($"Could not read input '{hexinput}': {e.Message}");
                }
            }
        }

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
            catch (Exception e) {
                return $"{e.Message} You dun messed up.";
            }
        }
    } 
}