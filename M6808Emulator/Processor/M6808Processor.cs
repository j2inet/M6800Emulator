using M6808Emulator.S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M6808Emulator.SystemComponents;
using M6808Emulator.Instructions;
using System.Reflection;

namespace M6808Emulator.Processor
{


    public  class M6808Processor
    {

        private Dictionary<byte, Instruction> instructionMapping = new Dictionary<byte, Instruction>();

        public M6808Processor()
        {
            var typeList = this.GetType().Assembly.GetExportedTypes().Where(t => t.IsSubclassOf(typeof(Instruction)));
            foreach (var type in typeList)
            {
                if (type != null)
                {
                    Instruction n = Activator.CreateInstance(type) as Instruction;
                    if (n != null)
                    {
                        instructionMapping[n.Opcode] = n;
                    }
                }

            }
        }

        #region ghost variables
        ulong _virtualTimeCounter;
        bool _machineOnHalt = false;

        protected void VTimeAdd(int ticks)
        {
            _virtualTimeCounter += (ulong)ticks;
        }
        #endregion

        const ushort INTERNAL_MEMORY_SIZE = 128;

        #region Registers
        internal  byte A { get; set; }
        internal byte B { get; set; }
        private short I{ get; set;  }
        private int PC { get; set;  }
        private int SP { get; set; }

        byte _flags;
        private byte Flags {  get => _flags; set => _flags = value;}
        public enum FlagMask
        {
            Carry = 0x01,
            Overflow = 0x02, 
            Zero = 0x04, 
            Negative = 0x08, 
            Interrupt = 0x10,
            HalfCarry = 0x20
        }
        #endregion Registers

        #region Busses

        Bus<byte> DataBus { get; } = new Bus<byte>();
        Bus<ushort> AddressBus { get; } = new Bus<ushort>();

        #endregion

        #region Internal Memory
        private byte[] internalMemory = new byte[INTERNAL_MEMORY_SIZE];
        #endregion

        #region Signal Lines 

        public Bus<bool> N_Halt { get; } = new Bus<bool>();

        public Bus<bool> Read_N_Write_Bus { get; } = new Bus<bool>(); 
        
        public Bus<bool> ValidMemoryAddress { get; } = new Bus<bool>();

        public Bus<bool> BusAvailable { get; } = new Bus<bool>();

        public Bus<bool> N_Irq { get; } = new Bus<bool>();

        public Bus<bool> N_Reset { get; } = new Bus<bool>();

        public Bus<bool> N_NMI { get; } = new Bus<bool>();


        #endregion


        #region External


        protected byte ReadAddressByte(ushort address)
        {
            byte retVal = 0xFF;
            if(address < INTERNAL_MEMORY_SIZE)
            {
                retVal = internalMemory[address];
            }
            else
            {
                this.AddressBus.Data = address;
                this.Read_N_Write_Bus.Data = true;
                this.ValidMemoryAddress.Data = true;
                retVal = DataBus.Data;
                this.ValidMemoryAddress.Data = false;
            }
            return retVal;
        }

        protected ushort ReadAddressDoubleByte(ushort address)
        {
            ushort retVal;
            var b1 = ReadAddressByte(address);
            var b2 = ReadAddressByte((ushort)(address+(ushort)1));
            ushort highByte = (ushort)( ((ushort)b2) << 0x08);
            retVal = (ushort)(highByte | (ushort)b1);
            return retVal;
        }

        #endregion




        public void Step()
        {            
            if(N_Reset.Data)
            {
                PC = ReadAddressByte(0xfffe);
                return;
            }

            if(!N_Halt.Data)
            {
                BusAvailable.Data = true;
                _machineOnHalt = true;
                return;
            }

            if(!N_NMI.Data)
            {

            }

            if(!N_Irq.Data)
            {

            }

        }

    }
}
