using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SUT23_Labb3_API.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        public string InterestName { get; set; }
        public string InterestDescription { get; set; }
        [JsonIgnore]
        public ICollection<InterestPersonLink> InterestPersonLinks { get; set; }
    }
}
