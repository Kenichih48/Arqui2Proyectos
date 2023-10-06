namespace Proyecto1 {

    /// <summary>
    /// Represents a single cache line in a cache memory.
    /// </summary>
    public class CacheLine
    {
        public byte[] data;
        public bool Valid { get; set; }
        public bool Dirty { get; set; }
        public int Tag { get; set; }
        public int Line {  get; set; }
        public StateMachine StateMachine;
        public string Protocol;

        public CacheLine(int line, string protocol)
        {
            Tag = -1;
            Line = line;
            Valid = false;
            Dirty = false;
            data = new byte[4];

            Protocol = protocol;
            StateMachine = new StateMachine(protocol);
            
           
        }

        /// <summary>
        /// Updates the cache line with new data and attributes.
        /// </summary>
        /// <param name="data">The new data to store in the cache line.</param>
        /// <param name="tag">The new tag to associate with the cache line.</param>
        /// <param name="valid">A value indicating whether the cache line is valid.</param>
        /// <param name="dirty">A value indicating whether the cache line is dirty.</param>
        public void UpdateLine(byte[] data, int tag, bool valid, bool dirty)
        {
            this.data = data;
            Tag = tag;
            Valid = valid;
            Dirty = dirty;
        }

        /// <summary>
        /// Cleans the cache line by resetting its attributes.
        /// </summary>
        public void Clean() {
            Tag = -1;
            Valid = false;
            Dirty = false;
        }
    }
}