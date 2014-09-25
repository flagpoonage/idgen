using JH.Codesequences.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataSeq = new byte[]
            {
                74, 76, 45, 65, 65, 48, 48, 48, 45, 48, 48, 48, 65, 88, // Current Position
                29,
                74, // Static J
                30,
                76, // Static L
                30,
                45, // Static Hyphen
                30,
                26, 1, // Position 3 - PATTERN 1
                30,
                26, 1, // Position 4 - PATTERN 1
                30,
                26, 0, // Position 5 - PATTERN 0
                30,
                26, 0, // Position 6 - PATTERN 0
                30,
                26, 0, // Position 7 - PATTERN 0
                30,
                45, // Static Hyphen
                30,
                26, 0, // Position 9 - PATTERN 0
                30,
                26, 0, // Position 10 - PATTERN 0
                30,
                26, 0, // Position 11 - PATTERN 0
                30,
                26, 1, // Position 12 - PATTERN 1
                30,
                88, // Static X
                29,
                48, 49, 50, 51, 52, 53, 54, 55, 56, 57, // PATTERN 0
                30,
                65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84 ,85 ,86, 87, 88, 89, 90, // PATTERN 1
                29,
                0, 1, 2, 8, 13, 11, 10, 9, 12, 7, 6, 5, 4, 3 // SEQUENCE
            };
            
            var b = Convert.ToBase64String(dataSeq);

            var c = Encoding.UTF8.GetBytes(b);

            var s = Convert.ToBase64String(c);

            var d = Convert.FromBase64String(b);

            var utf = Encoding.ASCII.GetString(d);

            var cs = CodeSequence.CreateFromBytes(dataSeq, false);

            var sb = new StringBuilder();

            for (int i = 0; i < 5000; i++)
            {
                cs.Bump();
                sb.AppendLine(cs.GetCurrentCode());
            }

            using (var fs = new StreamWriter("codes.txt", false))
            {
                fs.Write(sb.ToString());
            }
        }
    }
}
