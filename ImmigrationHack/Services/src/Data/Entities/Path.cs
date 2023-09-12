using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImmigrationHack.Services.src.Data.Entities
{

    public class Path
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Path>? NextEligiblePaths { get; set; }
        [ForeignKey("DocumentType")]
        public Guid DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}

