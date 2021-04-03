// ------------------------------------------------------------------------------------------------------------------------
// File name:       Bitutilities.cs
// Project name:    ISA
// Project description: Decoder for our awesome Detached-Toe 16-bit RISC ISA.
// ------------------------------------------------------------------------------------------------------------------------
// Creator's name and email: Harrison Lee Pollitte. pollitteh@etsu.edu. Edgar Bowlin III, bowline@etsu.edu. nelsondk@etsu.edu 
// Course Name: CSCI-4727 Computer Architecture
// Course Section: 940
// Creation Date: 03/31/2021
// ------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    /// <summary>
    /// class that stores functions used elswhere in the program
    /// </summary>
    static class BitUtilities {

        /// <summary>
        /// Extract designated bits, relative to the right (LSB).
        /// </summary>
        /// <param name="number">the number to manipulate</param>
        /// <param name="size">the number of bits to include</param>
        /// <param name="position">the starting position, relative to the right (LSB).</param>
        /// <returns>returns extracted bits</returns>
        public static int ExtractBits(int number, int size, int position) {
            return (int)(((1 << size) - 1) & (number >> position));
        }


        /// <summary>
        /// used to mask input and shift bits to get correct values
        /// </summary>
        /// <param name="input">instruction bits</param>
        /// <param name="startBit">the beginning bit we want</param>
        /// <param name="endBit"> the ending bit we want</param>
        /// <returns> returns the masked and shifted bits</returns>
        public static int MaskInput(int input, int startBit, int endBit) {
            return (input & CreateBitMask(startBit, endBit)) >> startBit;
        }

        // Everything between STARTBIT and ENDBIT is preserved. Else 0'd out.
        public static int CreateBitMask(int startBit, int endBit) {
            int mask = 0;
            for (int i = startBit; i <= endBit; ++i) {
                mask |= 1 << i;
            }
            return (int)mask;
        }
    }
}
