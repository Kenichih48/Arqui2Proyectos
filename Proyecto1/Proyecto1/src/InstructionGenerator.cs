namespace Proyecto1
{
    /// <summary>
    /// Random code generator for a processing element.
    /// </summary>
    internal class InstructionGenerator
    {
        private readonly int minInstrs;
        private readonly int maxInstrs;
        private int instrLen;
        private readonly List<string> instructions;
        private readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="InstructionGenerator"/> class.
        /// </summary>
        /// <param name="minInstrs">
        /// Minimum amount of instructions.
        /// </param>
        /// <param name="maxInstrs">
        /// Maximum amount of instructions.
        /// </param>
        public InstructionGenerator(int minInstrs, int maxInstrs)
        {
            random = new Random();
            instructions = new List<string>();
            this.minInstrs = minInstrs;
            this.maxInstrs = maxInstrs; 
        }

        /// <summary>
        /// Generates a list of random instructions.
        /// </summary>
        /// <returns>A list of randomly generated instructions.</returns>
        public List<string> MakeInstructions(int[] randomAddr)
        {
            instrLen = random.Next(minInstrs, maxInstrs+1);

            while (instructions.Count < instrLen)
            {
                int i = random.Next(0, 3);
                (int type, int reg) = MakeRandomInstr();

                
                switch (type)
                {
                    // incr
                    case 0:
                        MakeIncrInstr(reg);
                        MakeWriteInstr(reg, randomAddr[i]);
                        MakeReadInstr(reg, randomAddr[i]);
                        break;
                    // read
                    case 1:
                        MakeReadInstr(reg, randomAddr[i]);
                        MakeIncrInstr(reg);
                        MakeWriteInstr(reg, randomAddr[i]);
                        break;
                    // write
                    case 2:
                        MakeWriteInstr(reg, randomAddr[i]);
                        break;
                    default:
                        break;
                }
            }
            return instructions;
        }

        /// <summary>
        /// Generates a random 'assembly' instruction.
        /// </summary>
        /// <returns>
        /// A tuple containing the instruction type and register.
        /// </returns>
        private (int, int) MakeRandomInstr()
        {
            int reg = random.Next(0, 9);
            int instrType = random.Next(0, 3);
            return (instrType, reg);
        }

        /// <summary>
        /// Generates an increment instruction for the specified register.
        /// </summary>
        /// <param name="reg">The register to increment.</param>
        private void MakeIncrInstr(int reg)
        {
            string instr = "incr r" + reg;
            instructions.Add(instr);
        }

        /// <summary>
        /// Generates a read instruction for the specified register and address.
        /// </summary>
        /// <param name="reg">The register to read into.</param>
        /// <param name="addr">The address to read from.</param>
        private void MakeReadInstr(int reg, int addr)
        {
            string instr = "read " + addr + " r" + reg;
            instructions.Add(instr);
        }

        /// <summary>
        /// Generates a write instruction for the specified register and address.
        /// </summary>
        /// <param name="reg">The register to write from.</param>
        /// <param name="addr">The address to write to.</param>
        private void MakeWriteInstr(int reg, int addr)
        {
            string instr = "write " + addr + " r" + reg;
            instructions.Add(instr);
        }
    }
}