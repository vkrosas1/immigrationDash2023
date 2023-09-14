using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImmigrationHack.Services.src.Data.Entities
{
    public class Form
    {
        [Key]
        public Guid Id { get; set; }

        public string DocumentTypeName { get; set; }

        //comma seperated PathNames
        public string? EligiblePaths { get; set; }
    }
}

