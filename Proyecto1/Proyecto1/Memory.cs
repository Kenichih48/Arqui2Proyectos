namespace Proyecto1
{
    /// <summary>
    /// Represents byte-addressable RAM memory.
    /// </summary>
    public class Memory
    {
        private readonly byte[] memory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Memory"/> class.
        /// </summary>
        /// <param name="sizeInBytes">
        /// Size of the RAM memory in bytes.
        /// </param>
        public Memory(int sizeInBytes = 64)
        {
            if (sizeInBytes % 4 != 0)
            {
                throw new ArgumentException("Size in bytes must be a multiple of 4.");
            }

            memory = new byte[sizeInBytes];
        }

        /// <summary>
        /// Takes memory address and returns the data in it.
        /// </summary>
        /// <param name="address">
        /// Desired memory address to read.
        /// </param>
        /// <returns>
        /// The byte data in the memory address.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when parameter is greater than size of memory.
        /// </exception>
        public byte ReadAddr(int address)
        {
            if (address >= 0 && address < memory.Length)
            {
                return memory[address];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(address),
                    $"Address must be inside the memory range.");
            }
        }

        /// <summary>
        /// Takes memory address and writes the specified data to it.
        /// </summary>
        /// <param name="address">
        /// Desired memory address to write to.
        /// </param>
        /// <param name="data">
        /// The data to be written.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when parameter is greater than size of memory.
        /// </exception>        
        public void WriteByte(int address, byte data)
        {
            if (address >= 0 && address < memory.Length)
            {
                memory[address] = data;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(address),
                    $"Address must be inside the memory range.");
            }
        }
    }
}