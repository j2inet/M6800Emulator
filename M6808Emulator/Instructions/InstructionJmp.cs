using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6808Emulator.Instructions
{
     public class InstructionJmp:Instruction
    {
        public InstructionJmp():base(0x6e, 2, "JMP", "Jump to Index")
        {

        }
    }

    public class InstructionJmpExtended : Instruction
    {
        public InstructionJmpExtended():base(0x7e, 3, "JMP", "Jump to Index Extended")
    }
}
