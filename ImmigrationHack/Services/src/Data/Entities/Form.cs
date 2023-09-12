using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImmigrationHack.Services.src.Data.Entities
{
    public class Form
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("DocumentType")]
        public Guid DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public virtual IEnumerable<Path>? PathsRequired { get; set; }
    }
}

