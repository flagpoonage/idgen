using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH.Codesequences.Harness
{
    public class PatternTemplate
    {
        public byte[] Data { get; set; }

        public string Name { get; set; }

        public bool UseSelectionOrdering { get; set; }

        public PatternTemplate()
        {

        }

        public PatternTemplate(string dataString)
        {
            var chars = dataString.ToCharArray();

            this.Data = chars.Select(a => (byte)a).ToArray();
        }

        public static PatternTemplate LoadFromFile(string filename)
        {
            var pt = new PatternTemplate() { Name = Path.GetFileNameWithoutExtension(filename) };

            using (var sr = new StreamReader(filename))
            {
                var str = sr.ReadToEnd();

                if (string.IsNullOrEmpty(str))
                {
                    return null;
                }

                pt.UseSelectionOrdering = str[0] != '0';

                if (string.IsNullOrEmpty(str.Substring(1)))
                {
                    return null;
                }

                pt.Data = Encoding.ASCII.GetBytes(str.Substring(1));
            }

            return pt;
        }
    }
}
