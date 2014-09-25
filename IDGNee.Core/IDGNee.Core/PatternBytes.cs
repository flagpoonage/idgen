using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDGNee.Core
{
    internal static class PatternBytes
    {
        internal static IDGPatternType GetPatternType(string s)
        {
            switch(s.ToLower())
            {
                case "b62":
                case "base-62":
                    return IDGPatternType.Base62;
                case "b10":
                case "base-10":
                    return IDGPatternType.Base10;
                case "b36-u":
                case "base-36-upper":
                    return IDGPatternType.Base36Uppercase;
                case "b36-l":
                case "base-36-lower":
                    return IDGPatternType.Base36Lowercase;
                case "alp-u":
                case "alpha-upper":
                    return IDGPatternType.AlphabeticUppercase;
                case "alp-l":
                case "alpha-lower":
                    return IDGPatternType.AlphabeticLowercase;
                case "alp":
                case "alphabetic":
                    return IDGPatternType.Alphabetic;
                case "hex-u":
                case "hexidecimal-upper":
                    return IDGPatternType.HexidecimalUppercase;
                case "hex-l":
                case "hexidecimal-lower":
                    return IDGPatternType.HexidecimalLowercase;
                case "bin":
                case "binary":
                    return IDGPatternType.Binary;
                case "spc":
                case "space":
                    return IDGPatternType.Static;
                default:
                    return IDGPatternType.Invalid;
            }
        }

        internal static IEnumerable<byte> GetBytes(IDGPatternType predefinedType)
        {
            switch (predefinedType)
            {
                case IDGPatternType.Alphabetic:
                    return new byte[]{
                        65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,
                        97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,
                        117,118,119,120,121,122
                    };
                case IDGPatternType.AlphabeticLowercase:
                    return new byte[]{
                        97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,
                        117,118,119,120,121,122
                    };
                case IDGPatternType.AlphabeticUppercase:
                    return new byte[]{
                        65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90
                    };
                case IDGPatternType.Base10:
                    return new byte[]{
                        48,49,50,51,52,53,54,55,56,57,
                    };
                case IDGPatternType.Base36Lowercase:
                    return new byte[]{
                        48,49,50,51,52,53,54,55,56,57,
                        97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,
                        117,118,119,120,121,122
                    };
                case IDGPatternType.Base36Uppercase:
                    return new byte[]{
                        48,49,50,51,52,53,54,55,56,57,
                        65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90
                    };
                case IDGPatternType.Base62:
                    return new byte[]{
                        48,49,50,51,52,53,54,55,56,57,
                        65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,
                        97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,
                        117,118,119,120,121,122
                    };
                case IDGPatternType.Binary:
                    return new byte[] { 48, 49 };
                case IDGPatternType.Custom:
                    return new byte[] { };
                case IDGPatternType.HexidecimalLowercase:
                    return new byte[] {
                        48,49,50,51,52,53,54,55,56,57,97,98,99,100,101,102
                    };
                case IDGPatternType.HexidecimalUppercase:
                    return new byte[] {
                        48,49,50,51,52,53,54,55,56,57,65,66,67,68,69,70
                    };
                default:
                    return null;
            }
        }

    }
}
