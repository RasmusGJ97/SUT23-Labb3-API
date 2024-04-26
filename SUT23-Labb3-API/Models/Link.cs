using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SUT23_Labb3_API.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public string LinkName { get; set; }
        [JsonIgnore]
        public ICollection<InterestPersonLink> InterestPersonLinks { get; set; }
    }
}
