using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6808Emulator.Instructions
{
    public abstract class InstructionBranch : Instruction
    {
        public InstructionBranch(byte instruction) : base(instruction, 1, "Conditional Branch", "Jump to offset")
        {
           
        }

        protected abstract bool ConditionMet();
    }

    public class InstructionBranchCarryClear : InstructionBranch
    {
        InstructionBranchCarryClear() : base(0x24)
        {

        }
    }

    public class InstructionBranchCarrySet : InstructionBranch
    {
        public InstructionBranchCarrySet() : base(0x25)
        {

        }
    }

    public class InstructionBranchZero : InstructionBranch
    {
        public InstructionBranchZero() : base(0x27)
        {

        }
    }

    public class InstructionBranchGreaterThanOrEqualZero:InstructionBranch
    {
        public InstructionBranchGreaterThanOrEqualZero():base(0x2c)
        {

        }
    }

    public class InstructionBranchGreaterThanZero:InstructionBranch
    {
        public InstructionBranchGreaterThanZero():base(0x2e)
        {

        }
    }

    public class InstructionBranchIfAccomulatorGreaterInstructionBranch:InstructionBranch
    {
        public InstructionBranchIfAccomulatorGreaterInstructionBranch():base(0x22)
        {

        }
    }
}