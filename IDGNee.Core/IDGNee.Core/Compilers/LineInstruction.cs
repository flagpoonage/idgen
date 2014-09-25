using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDGNee.Core.Compilers
{
    public class LineInstruction
    {
        public LineInstructionType Type { get; set; }

        public string[] Values { get; set; }

        public int InstructionIndex { get; set; }
    }
}
