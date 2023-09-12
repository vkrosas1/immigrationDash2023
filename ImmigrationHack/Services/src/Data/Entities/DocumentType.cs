using System.ComponentModel.DataAnnotations;

namespace ImmigrationHack.Services.src.Data.Entities
{

    public class DocumentType
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

