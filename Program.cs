using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISA_Decoder_16Bit;


namespace ISA_Decoder_16Bit {
    class Program {


        static void Main() {
            // Read Input
            String hexinput = "0000";
            int binaryInput;

            // [TODO]: Have exit condition

            while (true) {
                Console.WriteLine("Input a 4-digit hex string.\n");
                hexinput = Console.ReadLine();

                // Convert Input to unsigned 16-bit integer
                //binaryInput = Convert.ToUInt16(hexinput, 16);   // [TODO]: Convert to UInt16.TryParse()
                binaryInput = Convert.ToInt32(hexinput, 16);


                DecodeInput(binaryInput);

                // [DEBUG] Display output
                //Console.WriteLine(binaryInput);

                // Begin decoding

            }

            

        }

        private static void DecodeInput(int input) {
            


            // I Check instruction type (Bits 14-15)
            // I.A SHOW bits 14-15
            int bitmask = BitUtilities.CreateBitMask(14,15); //1100 0000 0000
            int maskedinput = input & bitmask;
            int opCodeSize = 0;
            switch (maskedinput) {
                case 0x0000:    //00 - data transfer
                    Console.Write("00");
                    opCodeSize = 1;
                    break;
                case 0x4000:    //01 - arithmetic/logical
                    Console.Write("01");
                    opCodeSize = 4;
                    break;
                case 0x8000:    //10 - flow control
                    Console.Write("10");
                    opCodeSize = 2;
                    break;
                default:
                    Console.Write("Instruction Type broke");
                    break;
            }
            Console.Write(" ");
            // II Check Operation Code
            // II.A Check size of operation code

            // II.B Prepare mask
            int endBit = 15 - 2;
            int startBit = endBit - opCodeSize;
            bitmask = BitUtilities.CreateBitMask(startBit, endBit);
            maskedinput = input & bitmask;

            Console.Write(input & BitUtilities.CreateBitMask(startBit, endBit));

            // II.C Mask and compare
            switch(opCodeSize) {
                
                    
            }
            // III Other bits
            // III.A Check if needed


        }


        
}