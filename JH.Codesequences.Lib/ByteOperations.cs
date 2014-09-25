using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH.Codesequences.Lib
{
    public static class ByteOperations
    {
        public static int IndexOf(this byte[] data, byte b)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == b)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int[] AllIndexesOf(this byte[] data, byte b)
        {
            var list = new List<int>();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == b)
                {
                    list.Add(i);
                }
            }

            return list.ToArray();
        }

        public static int IndexOfValues(this IEnumerable<byte[]> data, byte[] bytes)
        {
            for(int i = 0; i < data.Count(); i++)
            {
                if (data.ElementAt(i).IsEqualTo(bytes, true))
                {
                    return i;
                }
            }

            return -1;
        }

        public static byte[] RemoveFirst(this byte[] data, byte b)
        {
            var bIdx = data.IndexOf(b);

            var before = bIdx;
            var after = data.Length - bIdx - 1;

            var bFront = new byte[before];

            var bBack = new byte[after];

            Array.Copy(data, 0, bFront, 0, bIdx);
            Array.Copy(data, bIdx + 1, bBack, 0, after);

            data = new byte[data.Length - 1];

            Array.Copy(bFront, 0, data, 0, bFront.Length);
            Array.Copy(bBack, 0, data, bFront.Length, bBack.Length);

            return data;
        }
        
        public static byte[] AddToEnd(this byte[] data, byte b)
        {
            var buffer = new byte[data.Length + 1];

            Array.Copy(data, buffer, data.Length);

            buffer[buffer.Length - 1] = b;

            return buffer;
        }

        public static byte[] Sub(this byte[] data, int startIndex)
        {
            var length = data.Length - startIndex;

            return ByteOperations.Sub(data, startIndex, length);
        }

        public static byte[] Sub(this byte[] data, int startIndex, int length)
        {
            var b = new byte[length];

            Array.Copy(data, startIndex, b, 0, b.Length);

            return b;
        }

        public static bool IsEqualTo(this byte[] data, byte[] compare, bool includeValueOrder)
        {
            if(data.Length != compare.Length)
            {
                return false;
            }

            if (includeValueOrder)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] != compare[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (compare.IndexOf(data[i]) == -1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static byte[][] Split(this byte[] data, byte splitter)
        {
            var splitList = new List<byte[]>();

            for (int i = 0; i < data.Length; i++)
            {
                var dCopy = new byte[data.Length - i];

                Array.Copy(data, i, dCopy, 0, dCopy.Length);

                var seperatorIndex = dCopy.IndexOf(CodeSequenceParser.RecordSeperator);

                if (seperatorIndex > -1)
                {
                    var s = new byte[seperatorIndex];

                    Array.Copy(dCopy, s, seperatorIndex);

                    splitList.Add(s);

                    i += seperatorIndex;
                }
                else
                {
                    splitList.Add(dCopy);

                    break;
                }
            }

            return splitList.ToArray();
        }
    }
}
