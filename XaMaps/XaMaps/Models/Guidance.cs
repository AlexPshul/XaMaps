using System.Collections.Generic;

namespace XaMaps.Models
{
    public class Guidance
    {
        public List<Instruction> Instructions { get; set; }
        public List<InstructionGroup> InstructionGroups { get; set; }
    }
}