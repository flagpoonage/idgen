namespace JH.Codesequences.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CodeSequence
    {
        internal byte[] DataSequence { get; set; }

        public Position[] Positions { get; internal set; }

        internal byte[] Sequence { get; set; }

        internal bool SequenceRecycleAllowed { get; set; }

        private Random Randomizer { get; set; }

        public bool IsComplete { get; private set; }

        internal CodeSequence()
        {
            this.Randomizer = new Random(Environment.TickCount);
        }

        public string GetCurrentCode()
        {
            var buffer = new byte[this.Positions.Length];

            var viewSorted = this.Positions.OrderByDescending(a => a.SequenceViewIndex).ToArray();

            for (int i = viewSorted.Length - 1; i >= 0; i--)
            {
                buffer[i] = viewSorted[this.Positions.Length - 1 - i].CurrentPosition;
            }

            return Encoding.ASCII.GetString(buffer);
        }

        public static CodeSequence CreateFromBytes(byte[] sequence, bool allowSequenceRecyle)
        {
            return CodeSequenceParser.ParseSequence(sequence, allowSequenceRecyle);
        }

        public static CodeSequence CreateFromPositions(Position[] positions, bool allowSequenceRecyle)
        {
            var cs = new CodeSequence()
            {
                DataSequence = null,
                IsComplete = false,
                Sequence = null,
                SequenceRecycleAllowed = allowSequenceRecyle,
                Positions = positions
            };

            return cs;
        }

        public void Advance(int count)
        {
            var advanceNext = count;

            var pordered = this.Positions.OrderBy(a => a.SequenceRankIndex);

            foreach (var p in pordered)
            {
                if (advanceNext == 0)
                {
                    return;
                }

                advanceNext = p.Advance(advanceNext);
            }
        }

        public void Reset()
        {
            foreach (var p in this.Positions)
            {
                p.Reset();
            }
        }

        public void Max()
        {
            foreach (var p in this.Positions)
            {
                p.CurrentPosition = p.AvailableCharacters[p.AvailableCharacters.Length - 1];
            }
        }

        public void Bump()
        {
            this.Advance(1);
        }

        public void Random()
        {
            foreach (var position in this.Positions)
            {
                position.CurrentPosition =
                    position.AvailableCharacters[this.Randomizer.Next(0, position.AvailableCharacters.Length)];
            }
        }

        public SequenceValidationResult Validate(string s)
        {
            var bytes = Encoding.ASCII.GetBytes(s);

            var actual = bytes.Reverse().ToArray();

            if (bytes.Length != this.Positions.Length)
            {
                return new SequenceValidationResult()
                {
                    IsValid = false,
                    Message = string.Format("The code [{0}] does not match the sequence length.", s)
                };
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (this.Positions[i].AvailableCharacters.IndexOf(actual[i]) == -1)
                {
                    return new SequenceValidationResult()
                    {
                        IsValid = false,
                        Message = string.Format("The character [{0}] at position [{1}] is invalid", Encoding.Default.GetString(new byte[] { actual[i] }), i)
                    };
                }
            }

            return new SequenceValidationResult() { IsValid = true };
        }
    }
}
