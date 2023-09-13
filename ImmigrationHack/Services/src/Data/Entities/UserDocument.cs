using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImmigrationHack.Services.src.Data.Entities
{

    public class UserDocument
    {
        [Key]
        public Guid Id { get; set; }

        // Key
        public DateTime ExpirationDate { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueCountry { get; set; }
        [DefaultValue(false)]
        public bool IsOptional { get; set; }

        [ForeignKey("DocumentType")] 
        public Guid DocumentTypeId { get; set; }
        public DocumentType? DocumentType { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User? User { get; set; }

    }
}

