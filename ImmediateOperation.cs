using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    abstract class ImmediateOperation: Operation {
        private int immediateSwitchBitStart;    // what bit position does it start
        private int immediateSwitchBitEnd;      // what bit position does it end
        private int ImmediateSwitchBitValue;    // 0 or 1

        /// <summary>
        /// Decode value of the immediateSwitch.
        /// </summary>
        /// <param name="instructionBits">our instruction</param>
        public abstract void DecodeImmediateSwitch(int instructionBits);

    }
}
