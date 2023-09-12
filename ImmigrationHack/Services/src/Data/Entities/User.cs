using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImmigrationHack.Services.src.Data.Entities
{

    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        // Key
        //public DateTime Date { get; set; }
        public string? CitizenCountry { get; set; }
        public string? CurrentStatus { get; set; }

    }
}

