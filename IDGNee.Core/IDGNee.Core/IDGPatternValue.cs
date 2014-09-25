using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDGNee.Core
{
    public class IDGPatternValue : IDGBytes
    {
        public int FormatOrder { get; set; }

        public IDGPatternType PatternType { get; set; }

        public IDGPatternValue(IEnumerable<byte> values)
        {
            this.AddRange(values);
            this.PatternType = values.Count() == 1 ? IDGPatternType.Static : IDGPatternType.Custom;
        }

        public IDGPatternValue(IDGPatternType predefinedType)
        {
            this.AddRange(PatternBytes.GetBytes(predefinedType));
            this.PatternType = predefinedType;
        }
    }
}
