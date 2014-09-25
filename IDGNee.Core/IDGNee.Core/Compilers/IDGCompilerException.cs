using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDGNee.Core.Compilers
{
    public class IDGCompilerException : Exception
    {
        public IDGCompilerException(string message) : base(message)
        {

        }
        public IDGCompilerException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
