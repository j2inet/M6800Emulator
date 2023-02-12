using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6808Emulator.Instructions
{
    internal class InstructionNop: Instruction
    {
        public InstructionNop():base(0x01, 0, "NOP", "No Operation")
        {

        }

        protected override void Execute(byte[] args)
        {
            
        }
    }
}
