namespace Proyecto1
{
    /// <summary>
    /// Random code generator for a processing element.
    /// </summary>
    internal class InstructionGenerator
    {
        private int instrLen;
        private readonly List<string> instructions;
        private readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="InstructionGenerator"/> class.
        /// </summary>
        public InstructionGenerator()
        {
            random = new Random();
            instructions = new List<string>();
        }

        /// <summary>
        /// Generates a list of random instructions.
        /// </summary>
        /// <returns>A list of randomly generated instructions.</returns>
        public List<string> MakeInstructions()
        {
            instrLen = random.Next(5, 9);

            while (instructions.Count < instrLen)
            {
                (int type, int addr, int reg) = MakeRandomInstr();

                switch (type)
                {
                    // incr
                    case 0:
                        MakeIncrInstr(reg);

                        int addrRandom = random.Next(0, 64);
                        MakeWriteInstr(reg, addrRandom);
                        MakeReadInstr(reg, addrRandom);
                        break;
                    // read
                    case 1:
                        MakeReadInstr(reg, addr);
                        MakeIncrInstr(reg);
                        MakeWriteInstr(reg, addr);
                        break;
                    // write
                    case 2:
                        MakeWriteInstr(reg, addr);
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
        /// A tuple containing the instruction type, address, and register.
        /// </returns>
        private (int, int, int) MakeRandomInstr()
        {
            int reg = random.Next(0, 9);
            int addr = random.Next(0, 64);
            int instrType = random.Next(0, 3);

            return (instrType, addr, reg);
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