namespace Proyecto1
{
    /// <summary>
    /// Represents a processing element in a simulated system.
    /// </summary>
    public class ProcessingElement
    {
        private int pc;
        public byte[] regs;
        private readonly Cache cache;
        public List<string> instrList;
        private readonly InstructionGenerator instrGenerator;

        /// <summary>
        /// Gets the list of instructions associated with this processing element.
        /// </summary>
        public List<string> InstrList
        {
            get { return instrList; }
        }

        /// <summary>
        /// Gets the current PC associated with this processing element.
        /// </summary>
        public int PC
        { 
            get { return pc; } 
        
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessingElement"/> class.
        /// </summary>
        /// <param name="id">The identifier of the processing element.</param>
        /// <param name="minInstrs">The minimum number of instructions to generate.</param>
        /// <param name="maxInstrs">The maximum number of instructions to generate.</param>
        public ProcessingElement(Cache cache, int minInstrs, int maxInstrs)
        {
            pc = 0;
            this.cache = cache;
            regs = new byte[9];
            instrList = new List<string>();
            instrGenerator = new InstructionGenerator(minInstrs, maxInstrs);
        }

        /// <summary>
        /// Generates a list of instructions for the processing element.
        /// </summary>
        public void GenerateInstructions()
        {
            instrList = instrGenerator.MakeInstructions();
        }

        /// <summary>
        /// Executes all instructions in the processing element's instruction list.
        /// </summary>
        public void ExecuteAll()
        {
            foreach (string instr in instrList)
            {
                DecodeInstr(instr);
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Executes the instruction at the current program counter (PC).
        /// </summary>
        public void ExecuteInstr()
        {
            DecodeInstr(instrList[pc]);
        }

        /// <summary>
        /// Decodes and executes an instruction represented by the given string.
        /// </summary>
        /// <param name="instr">The instruction string to decode and execute.</param>
        private void DecodeInstr(string instr)
        {
            string[] words = instr.Split();
            pc++;
            if (words[0].Equals("incr"))
            {
                string reg = words[1];
                string regNum = reg[1..];

                if (int.TryParse(regNum, out int regIndex))
                {
                    regs[regIndex]++;
                }
                else
                {
                    throw new InvalidOperationException("Invalid instruction format.");
                }
            }
            else
            {
                string reg = words[2];
                string regNum = reg[1..];
                string address = words[1];

                if (int.TryParse(regNum, out int regIndex) &&
                    int.TryParse(address, out int addrNum))
                {
                    if (words[0].Equals("read"))
                    {
                        byte data = cache.ReadAddr(addrNum);
                        regs[regIndex] = data;
                    }
                    else
                    {
                        byte data = regs[regIndex];
                        cache.WriteAddr(addrNum, data);
                    }
                }
                else
                {
                    throw new InvalidOperationException("Invalid instruction format.");
                }
            }
        }

        /// <summary>
        /// Resets the processor state by clearing the program counter, register array, and instruction list.
        /// </summary>
        public void Clean() {
            pc = 0;
            Array.Clear(regs, 0, regs.Length);
            instrList.Clear();
        }

        public void CleanRegs()
        {
            pc = 0;
            Array.Clear(regs, 0, regs.Length);
            
        }
    }
}