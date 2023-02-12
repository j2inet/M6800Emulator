using M6808Emulator.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6808Emulator.Instructions
{
    abstract public class Instruction
    {
        public Instruction(M6808Processor proc, byte opcode, int argSize = 0, string mnemonic = "", string description = "")
        {
            processor = proc;
            this.Opcode = opcode;
            this.Size = 1 + argSize;
            this.Mnemonic = mnemonic;
            this.Description= description;
        }

        public void Execute()
        {
            var operandSize = this.Size - 1;
            byte[] args = null;
            if (operandSize > 0)
            {
                args = new byte[operandSize];
            }
            Execute(args);
        }

        abstract protected void Execute(byte[] args);


        protected M6808Processor processor;
        public string Mnemonic { get; protected set;  }
        public int Size { get; protected set;  }
        public byte Opcode {  get; protected set; }

        public string Description { get; protected set; }
    }
}
