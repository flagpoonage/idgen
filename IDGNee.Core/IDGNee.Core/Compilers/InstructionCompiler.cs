using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDGNee.Core.Compilers
{
    public class InstructionCompiler
    {
        private IDGInstance compiled;

        public IDGInstance Compile(string instructionText)
        {
            var sr = new StringReader(instructionText);

            this.compiled = new IDGInstance();

            var s = string.Empty;

            var lineInstructions = new List<LineInstruction>();

            while ((s = sr.ReadLine()) != null)
            {
                var instruction = this.ParseLine(s);
                if (instruction != null)
                {
                    lineInstructions.Add(instruction);
                }
            }

            this.CreatePatternInstructions(lineInstructions);

            this.CreateFormatInstruction(lineInstructions);

            this.CreateDirectionInstruction(lineInstructions);

            this.CreateOrderInstruction(lineInstructions);

            return this.compiled;
        }

        private void CreateOrderInstruction(List<LineInstruction> lineInstructions)
        {
            var di = lineInstructions.Where(a => a.Type == LineInstructionType.Order).LastOrDefault();

            if (di == null)
            {
                return;
            }

            var order = new IDGBytes();

            var count = 0;
            foreach (var b in di.Values)
            {
                byte orderNumber = 0;
                if (!byte.TryParse(b, out orderNumber) || orderNumber < 0 || orderNumber >= this.compiled.Format.Count)
                {
                    throw new IDGCompilerException(string.Format("The order value [{0}] is not valid. It must represent a valid index in the format instruction", b));
                }

                order.Add(orderNumber);
                this.compiled.Format[count].FormatOrder = orderNumber;
                count++;
            }

            this.compiled.Order = order;
        }

        private void CreateDirectionInstruction(List<LineInstruction> lineInstructions)
        {
            var di = lineInstructions.Where(a => a.Type == LineInstructionType.Format).LastOrDefault();

            if (di == null)
            {
                return;
            }

            var direction = new IDGBytes();

            foreach (var b in di.Values)
            {
                if (b[0] == '0')
                {
                    direction.Add(0);
                }
                else
                {
                    direction.Add(1);
                }
            }

            this.compiled.Direction = direction;
        }

        private void CreateFormatInstruction(List<LineInstruction> lineInstructions)
        {
            var fi = lineInstructions.Where(a => a.Type == LineInstructionType.Format).LastOrDefault();

            if (fi == null)
            {
                throw new IDGCompilerException("There is no format instruction available for the compiler");
            }

            var format = new IDGFormat();

            var enc = new UTF8Encoding(false, true);

            try
            {
                var count = 0;
                foreach (var fins in fi.Values)
                {
                    if (fins.Length == 1)
                    {
                        format.Add(new IDGPatternValue(enc.GetBytes(new char[] { fins[0] })));
                    }
                    else
                    {
                        var pType = PatternBytes.GetPatternType(fins);

                        if (pType == IDGPatternType.Invalid)
                        {
                            var startChar = char.ToLowerInvariant(fins[0]);

                            if (startChar != 'p')
                            {
                                throw new IDGCompilerException(string.Format("Unable to determine pattern for fomat value [{0}] at position [{1}]", fins, count));
                            }

                            var rest = fins.Substring(1);

                            var patternNumber = 0;

                            if (!int.TryParse(rest, out patternNumber))
                            {
                                throw new IDGCompilerException(string.Format("Unable to determine pattern for fomat value [{0}] at position [{1}]", fins, count));
                            }

                            if (this.compiled.CustomerPatterns.Count - 1 < patternNumber)
                            {
                                throw new IDGCompilerException(string.Format("Pattern [{0}] in format position [{1}] does not exist", patternNumber, count));
                            }

                            format.Add(this.compiled.CustomerPatterns[patternNumber]);
                        }
                        else if (pType == IDGPatternType.Static)
                        {
                            format.Add(new IDGPatternValue(new byte[] { 20 }));
                        }
                        else
                        {
                            format.Add(new IDGPatternValue(pType));
                        }
                    }

                    count++;
                }
            }
            catch (EncoderFallbackException efx)
            {
                throw new IDGCompilerException(string.Format(
                    "Unable to encode format instruction character {0}", efx.CharUnknown));
            }

            this.compiled.Format = format;
        }

        private void CreatePatternInstructions(List<LineInstruction> lineInstructions)
        {
            var pi = lineInstructions.Where(a => a.Type == LineInstructionType.Pattern);

            this.compiled.CustomerPatterns = new List<IDGPatternValue>();

            foreach (var pattern in pi)
            {
                var result = this.ParsePatternInstruction(pattern);
                this.compiled.CustomerPatterns.Add(result);
            }
        }

        private IDGPatternValue ParsePatternInstruction(LineInstruction pattern)
        {
            foreach (var character in pattern.Values)
            {
                if (character.Length > 1)
                {
                    throw new IDGCompilerException(string.Format("Invalid character found in pattern{0}: [{1}]", pattern.InstructionIndex, character));
                }
            }

            var enc = new UTF8Encoding(false, true);

            byte[] bArr = null;

            try
            {
                bArr = enc.GetBytes(pattern.Values.Select(a => a[0]).ToArray());
            }
            catch (EncoderFallbackException efx)
            {
                throw new IDGCompilerException(string.Format(
                    "Unable to encode character {0} at position {1}", efx.CharUnknown, efx.Index));
            }

            var p = new IDGPatternValue(bArr);

            return p;
        }

        private LineInstruction ParseLine(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }

            return this.ReadInstruction(s);
        }

        private LineInstruction ReadInstruction(string s)
        {
            var ch = s[0];

            ch = char.ToLowerInvariant(ch);

            switch (ch)
            {
                case '#':
                    return new LineInstruction()
                    {
                        Type = LineInstructionType.Comment,
                        Values = new string[] { s.Substring(1) }
                    };
                case 'p':
                    return this.ReadPatternInstruction(s);
                case 'f':
                    return this.ReadFormatInstruction(s);
                case 'd':
                    return this.ReadDirectionInstruction(s);
                case 'o':
                    return this.ReadOrderInstruction(s);
                case 'c':
                    return this.ReadCurrentValue(s);
                default:
                    throw new IDGCompilerException(string.Format("The instruction [{0}] is not valid", s));
            }
        }

        private LineInstruction ReadCurrentValue(string s)
        {
            var parts = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1)
            {
                throw new IDGCompilerException(string.Format(
                    "No current values could be found, the current instruction is invalid [{0}]", s));
            }

            return new LineInstruction()
            {
                Type = LineInstructionType.Direction,
                Values = parts.Skip(1).ToArray()
            };
        }

        private LineInstruction ReadDirectionInstruction(string s)
        {
            var parts = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1)
            {
                throw new IDGCompilerException(string.Format(
                    "No direction values could be found, the direction instruction is invalid [{0}]", s));
            }

            return new LineInstruction()
            {
                Type = LineInstructionType.Direction,
                Values = parts.Skip(1).ToArray()
            };
        }

        private LineInstruction ReadOrderInstruction(string s)
        {
            var parts = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1)
            {
                throw new IDGCompilerException(string.Format(
                    "No order values could be found, the order instruction is invalid [{0}]", s));
            }

            return new LineInstruction()
            {
                Type = LineInstructionType.Order,
                Values = parts.Skip(1).ToArray()
            };
        }

        private LineInstruction ReadFormatInstruction(string s)
        {
            var parts = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1)
            {
                throw new IDGCompilerException(string.Format(
                    "No format values could be found, the format instruction is invalid [{0}]", s));
            }

            return new LineInstruction()
            {
                Type = LineInstructionType.Format,
                Values = parts.Skip(1).ToArray()
            };
        }

        private LineInstruction ReadPatternInstruction(string s)
        {
            var parts = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1)
            {
                throw new IDGCompilerException(string.Format(
                    "No pattern values could be found, the pattern instruction is invalid [{0}]", s));
            }

            if (parts[0].Length == 1)
            {
                throw new IDGCompilerException(string.Format(
                    "The pattern has no numeric index on it. Example: \"p0\", the pattern instruction is invalid [{0}]", s));
            }

            var instructionIndex = 0;

            var indexPart = parts[0].Substring(1);

            if (!int.TryParse(indexPart, out instructionIndex))
            {
                throw new IDGCompilerException(string.Format(
                    "The pattern has an invalid index on it, the pattern instruction is invalid [{0}]", s));
            }

            return new LineInstruction()
            {
                InstructionIndex = instructionIndex,
                Type = LineInstructionType.Pattern,
                Values = parts.Skip(1).ToArray()
            };
        }
    }
}
