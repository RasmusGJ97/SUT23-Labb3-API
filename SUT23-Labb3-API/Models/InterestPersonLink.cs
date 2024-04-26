using System.Diagnostics.CodeAnalysis;

namespace SUT23_Labb3_API.Models
{
    public class InterestPersonLink
    {
        public int PersonId { get; set; }
        public Person Persons { get; set; }
        public int InterestId { get; set; }
        public Interest Interests { get; set; }
        public int LinkId { get; set; }
        public Link Links { get; set; }
    }
}
