﻿namespace Proyecto1
{
    /// <summary>
    /// Represents byte-addressable RAM memory.
    /// </summary>
    public class Memory
    {
        public List<MemByteArray> memory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Memory"/> class.
        /// </summary>
        /// <param name="sizeInBytes">
        /// Size of the RAM memory in bytes.
        /// </param>
        public Memory(int rows = 16, int columns = 4)
        {
            int line = 0;
            memory = new List<MemByteArray>();
            for(int i = 0; i < rows; i++)
            {
                memory.Add(new MemByteArray(columns, line));
                line += 4;
            }
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
        public byte[] ReadAddr(int address)
        {
            string binaryAddr = Convert.ToString(address, 2);
            int desiredLength = 6;
            if (binaryAddr.Length < desiredLength)
            {
                binaryAddr = binaryAddr.PadLeft(desiredLength, '0');
            }
            string strLine = binaryAddr[..4];
            int line = Convert.ToInt32(strLine, 2);

            if (address >= 0 && address < 64)
            {
                return memory[line].Data;
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
        /// <param name="newLine">
        /// The new line to be written.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when parameter is greater than size of memory.
        /// </exception>        
        public void WriteByte(int memoryline, byte[] newLine)
        {
            if (memoryline >= 0 && memoryline < 64)
            {
                memory[memoryline].Data = newLine;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(memoryline),
                    $"Address must be inside the memory range.");
            }
        }

        /// <summary>
        /// Clean the memory data.
        /// </summary>
        public void Clean()
        {
            int line = 0;
            memory = new List<MemByteArray>();
            for (int i = 0; i < 16; i++)
            {
                memory.Add(new MemByteArray(4, line));
                line += 4;
            }
        }

        /// <summary>
        /// Class that represents a byte array.
        /// </summary>
        public class MemByteArray
        {
            public byte[] Data { get; set; }
            public int LineNumber { get; set; }

            public MemByteArray(int columns, int lineNumber) { 
                Data = new byte[columns];
                LineNumber = lineNumber;  
            }

            public byte Data0 => Data.Length > 0 ? Data[0] : (byte)0;
            public byte Data1 => Data.Length > 1 ? Data[1] : (byte)0;
            public byte Data2 => Data.Length > 2 ? Data[2] : (byte)0;
            public byte Data3 => Data.Length > 3 ? Data[3] : (byte)0;
        }

    }
}