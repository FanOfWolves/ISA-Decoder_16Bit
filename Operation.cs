using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Decoder_16Bit {
    abstract class Operation {
        protected string verb;
        protected string operationText;

        /// <summary>
        /// Given a bitstring, write out the actual operation text.
        /// </summary>
        /// <returns></returns>
        public abstract string DecodeOperation();
    }
}
