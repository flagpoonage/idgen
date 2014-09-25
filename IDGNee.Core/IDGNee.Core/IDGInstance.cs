using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDGNee.Core
{
    public class IDGInstance
    {
        public List<IDGPatternValue> CustomerPatterns { get; set; }

        public IDGFormat Format { get; set; }

        public IDGBytes Direction { get; set; }

        public IDGBytes Order { get; set; }
    }
}
