using System.ComponentModel.DataAnnotations;

namespace ImmigrationHack.Services.src.Data.Entities
{

    public class Path
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        //comma seperated documentTypeNames
        public string? DocumentTypes { get; set; }
    }
}

