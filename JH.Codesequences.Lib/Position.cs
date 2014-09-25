using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH.Codesequences.Lib
{
    public class Position
    {
        /// <summary>
        /// The current character held by this position
        /// </summary>
        public byte CurrentPosition { get; set; }

        /// <summary>
        /// The list of characters that this position can hold
        /// </summary>
        public byte[] AvailableCharacters { get; set; }

        /// <summary>
        /// The order at which this position is printed in the code sequence
        /// </summary>
        public int SequenceViewIndex { get; set; }

        /// <summary>
        /// The order at which this position incrememnts in the code sequence
        /// </summary>
        public int SequenceRankIndex { get; set; }

        /// <summary>
        /// The index of the currently held character in the list of available characters.
        /// </summary>
        internal int CurrentPositionIndex
        {
            get
            {
                return AvailableCharacters.IndexOf(CurrentPosition);
            }
            set
            {
                this.CurrentPosition = this.AvailableCharacters[this.CurrentPositionIndex];
            }
        }

        /// <summary>
        /// The number of times that this position can be incremented before it cycles
        /// </summary>
        internal byte CharactersRemaining
        {
            get
            {
                return (byte)(AvailableCharacters.Length - this.CurrentPositionIndex - 1);
            }
        }

        /// <summary>
        /// The length of the list of available characters
        /// </summary>
        internal byte TotalCharacters
        {
            get
            {
                return (byte)AvailableCharacters.Length;
            }
        }

        /// <summary>
        /// Resets this position to the first character in the list
        /// </summary>
        internal void Reset()
        {
            this.CurrentPosition = this.AvailableCharacters[0];
        }

        /// <summary>
        /// Advances this position by 1. If the position cycles, it will return 1.
        /// </summary>
        /// <returns>If cycled, 1; otherwise 0</returns>
        internal int Bump()
        {

            return this.Advance(1);
        }

        /// <summary>
        /// Advances this position by the specified number
        /// </summary>
        /// <param name="count">The number of times to advance this position</param>
        /// <returns>A number indicating how many times this position cycled</returns>
        internal int Advance(int count)
        {
            if (this.TotalCharacters == 1)
            {
                // Don't attempt to loop static positions.
                return count;
            }

            // How many cycles of this position will complete on the current count
            var loops = (double)count / (double)this.TotalCharacters;

            var loopCounter = (int)loops;

            // The amount of the count that will be dealt with by larger positions
            var largerPositions = loopCounter * this.TotalCharacters;

            // Actual number to advance the counter by
            var advanceBy = count - largerPositions;

            if (this.CharactersRemaining < advanceBy)
            {
                if (loopCounter == 0)
                {
                    loopCounter = 1;
                }

                var advanceReset = advanceBy - this.CharactersRemaining - 1;

                this.CurrentPosition = this.AvailableCharacters[advanceReset];

                this.CurrentPositionIndex = advanceReset;
            }
            else
            {
                this.CurrentPosition = this.AvailableCharacters[this.CurrentPositionIndex + advanceBy];
            }

            return loopCounter;
        }

        public byte[] OrderedCharacters
        {
            get
            {
                return this.AvailableCharacters.OrderBy(a => a).ToArray();
            }
        }
    }
}
