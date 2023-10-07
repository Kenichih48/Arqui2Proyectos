using Stateless;

namespace Proyecto1
{

    /// <summary>
    /// Represents a single cache line in a cache memory.
    /// </summary>
    public class CacheLine
    {
        public byte[] data { get; set; }
        public bool Valid { get; set; }
        public bool Dirty { get; set; }
        public int Tag { get; set; }
        public int Line { get; set; }
        public StateMachine StateMachine { get; set; }
        public string Protocol;

        public CacheLine(int line, string protocol)
        {
            Tag = -1;
            Line = line;
            Valid = false;
            Dirty = false;
            Protocol = protocol;
            data = new byte[4];
            StateMachine = new StateMachine(protocol);
        }

        /// <summary>
        /// Sets the cache coherence protocol for the <see cref="CacheLine"/> class.
        /// </summary>
        /// <param name="protocol">The protocol to be set.</param>
        public void SetProtocol(string protocol)
        {
            this.Protocol = protocol;
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
        public void Clean()
        {
            Tag = -1;
            Valid = false;
            Dirty = false;
            this.data = new byte[4];
            StateMachine = new StateMachine(this.Protocol);
        }

        public int Data0
        {
            get
            {
                if (data != null && data.Length > 0)
                {
                    return data[0];
                }
                return 0;
            }
        }

        public int Data1
        {
            get
            {
                if (data != null && data.Length > 0)
                {
                    return data[1];
                }
                return 0;
            }
        }

        public int Data2
        {
            get
            {
                if (data != null && data.Length > 0)
                {
                    return data[2];
                }
                return 0;
            }
        }

        public int Data3
        {
            get
            {
                if (data != null && data.Length > 0)
                {
                    return data[3];
                }
                return 0;
            }
        }
    }
}