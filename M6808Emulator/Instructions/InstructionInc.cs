using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6808Emulator.Instructions
{
    public  class InstructionInc_A:Instruction
    {
        InstructionInc_A():base(0x4c, 0, "INC A", "Increment accumulator A")
        {

        }
    }

    public class InstructionInc_B:Instruction
    {
        InstructionInc_B():base(0x5c, 0, "INC B", "Increment Accumulator B")
        {

        }
    }

    public class InstructionInc_Index : Instruction
    {
        InstructionInc_Index():base(0x6c, 1, "INC Index", "Increment Index")
        {

        }
    }

    public class InstructionInc_IndexExtended:Instruction
    {
        InstructionInc_IndexExtended():base(0x7c, 2, "INC Index extended", "Increment Index Extended")
        {

        }
    }
}
