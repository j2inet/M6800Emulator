using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6808Emulator.Instructions
{
    public class InstructionDec_A : Instruction
    {
        InstructionDec_A() : base(0x4A, 0, "Dec A", "Decrement accumulator A")
        {

        }
    }

    public class InstructionDec_B : Instruction
    {
        InstructionDec_B() : base(0x5A, 0, "Dec B", "Decrement Accumulator B")
        {

        }
    }

    public class InstructionDec_Index : Instruction
    {
        InstructionDec_Index() : base(0x6A, 1, "Dec Index", "Decrement Index")
        {

        }
    }

    public class InstructionDec_IndexExtended : Instruction
    {
        InstructionDec_IndexExtended() : base(0x7A, 2, "Dec Index extended", "Decrement Index Extended")
        {

        }
    }
}
