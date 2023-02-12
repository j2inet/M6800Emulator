using M6808Emulator.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6808Emulator.Instructions
{
    public class LDA_Immediate: Instruction
    {
        public LDA_Immediate(M6808Processor proc) : base(proc, 0x86, 1, "LDA A", "Load Accumulator A immediate")
        {
            
        }



        protected override void Execute(byte[] args)
        {
            processor.A = args[0];
        }
    }

    public class LDA_Address8:Instruction
    {
        public LDA_Address8() : base(0x96, 1, "LDA A", "Load Accumulator A address direct")
        {

        }

        p
    }

    public class LDA_A_Index:Instruction
    {
        public LDA_A_Index():base(0xA6, 1, "LDA A", "Load Accumulator A from Index")
        {

        }
    }

    public class LDA_A_Extended: Instruction
    {
        public LDA_A_Extended() : base(0xB6, 2, "LDA A", "Load accumulator extended")
        {

        }
    }


    public class LDA_B_Immediate : Instruction
    {
        public LDA_B_Immediate() : base(0xC6, 1, "LDA B" , "Load Accumulator A immediate")
        {

        }
    }

    public class LDA_B_Address8 : Instruction
    {
        public LDA_B_Address8() : base(0xD6, 1, "LDA B", "Load Accumulator A address direct")
        {

        }
    }

    public class LDA_B_Index : Instruction
    {
        public LDA_B_Index() : base(0xE6, 1, "LDA B", "Load Accumulator A from Index")
        {

        }
    }

    public class LDA_B_Extended : Instruction
    {
        public LDA_B_Extended() : base(0xB6, 2, "LDA B", "Load accumulator extended")
        {

        }
    }


}
