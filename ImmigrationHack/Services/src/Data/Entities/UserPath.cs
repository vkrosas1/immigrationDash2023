using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImmigrationHack.Services.src.Data.Entities
{
    public class UserPath
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<Path>? AvailablePaths { get; set; }

    }
}

