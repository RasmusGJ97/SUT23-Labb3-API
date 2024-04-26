using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SUT23_Labb3_API.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PhoneNr { get; set; }
        [JsonIgnore]
        public ICollection<InterestPersonLink> InterestPersonLinks { get; set; }
    }
}
