using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    static class BitUtilities {

        /// <summary>
        /// Extract designated bits, relative to the right (LSB).
        /// </summary>
        /// <param name="number">the number to manipulate</param>
        /// <param name="size">the number of bits to include</param>
        /// <param name="position">the starting position, relative to the right (LSB).</param>
        /// <returns></returns>
        public static int ExtractBits(int number, int size, int position) {
            return (int)(((1 << size) - 1) & (number >> position));
        }


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
