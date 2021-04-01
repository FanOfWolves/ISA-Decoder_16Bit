﻿///
///TODO: Add try-catch inside while loop to catch bad 
///
using System;

namespace ISA_Decoder_16Bit {
    class Program {
        static void Main() {
            // Read Input
            String hexinput = "0000";
            int binaryInput;

            while (true) {
                Console.WriteLine("Input a 4-digit hex string.\n");
                hexinput = Console.ReadLine();

                // Convert Input to unsigned 16-bit integer
                //binaryInput = Convert.ToUInt16(hexinput, 16);   // [TODO]: Convert to UInt16.TryParse()
                binaryInput = Convert.ToInt32(hexinput, 16);

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
        }

        private static string DecodeInput(int input) {

            InstructionType ourInstruction = null;

            // I Check instruction type (Bits 14-15)
            // I.A SHOW bits 14-15
            int bitmask = BitUtilities.CreateBitMask(14, 15); //1100 0000 0000
            int maskedinput = input & bitmask;
            switch (maskedinput) {
                case 0x0000:    //00 - data transfer
                    Console.Write("00");
                    ourInstruction = new DataTransferType();
                    break;
                case 0x4000:    //01 - arithmetic/logical
                    Console.Write("01");
                    ourInstruction = new ArithmeticType();
                    break;
                case 0x8000:    //10 - flow control
                    Console.Write("10");
                    ourInstruction = new FlowControlType();
                    break;
                default:
                    Console.Write("Instruction Type broke");
                    break;
            }

            try {
                // Decode input
                string output = ourInstruction.DecodeInstruction(input);
                return output;
            }
            catch (Exception e) {
                return $"{e.Message} You dun fucked up.";
            }
        }
    } 
}