using System.ComponentModel.DataAnnotations;

namespace ImmigrationHack.Services.src.Data.Entities
{

    public class Path
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual HashSet<DocumentType>? DocumentsRequired { get; set; }
        public virtual HashSet<Path>? MinPathRequired { get; set;}
    }
}

