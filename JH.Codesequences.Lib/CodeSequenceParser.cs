using System.Collections.Generic;

namespace JH.Codesequences.Lib
{
    public class CodeSequenceParser
    {
        internal const byte RecordSeperator = 30;

        internal const byte GroupSeperator = 29;

        internal const byte Substitute = 26;

        internal const byte NullCharacter = 0;

        public static CodeSequence ParseSequence(byte[] dataSequence, bool allowSequenceRecyle)
        {
            var cs = new CodeSequence();

            cs.SequenceRecycleAllowed = allowSequenceRecyle;

            cs.DataSequence = dataSequence;

            var groupSeperators = dataSequence.AllIndexesOf(GroupSeperator);
                        
            var currentPosition = dataSequence.Sub(0, groupSeperators[0]);

            var positionSequence = dataSequence.Sub(groupSeperators[0] + 1, groupSeperators[1] - groupSeperators[0] - 1);

            var positions = positionSequence.Split(RecordSeperator);

            var patternSequence = dataSequence.Sub(groupSeperators[1] + 1, groupSeperators[2] - groupSeperators[1] - 1);

            cs.Sequence = dataSequence.Sub(groupSeperators[2] + 1);

            var patterns = patternSequence.Split(RecordSeperator);

            cs.Positions = CodeSequenceParser.GeneratePositions(currentPosition, positions, patterns, cs.Sequence);
            
            return cs;
        }

        private static Position[] GeneratePositions(byte[] currentPosition, byte[][] positions, byte[][] patterns, byte[] sequence)
        {
            var pList = new List<Position>();

            for (int i = sequence.Length - 1; i >= 0; i--)
            {
                var p = new Position();

                // The current 'i' in the sequence, points to the index of the position.
                var b = sequence[sequence.Length - i - 1];

                p.SequenceViewIndex = sequence.Length - i - 1;
                p.SequenceRankIndex = b;

                var subPos = positions[i].IndexOf(Substitute);

                if (subPos == 0)
                {
                    var pattern = positions[i][1];

                    p.AvailableCharacters = patterns[pattern];
                    p.CurrentPosition = currentPosition[i];
                }
                else
                {
                    p.AvailableCharacters = positions[i];
                    p.CurrentPosition = currentPosition[i];
                }

                pList.Add(p);
            }

            return pList.ToArray();
        }
    }
}
