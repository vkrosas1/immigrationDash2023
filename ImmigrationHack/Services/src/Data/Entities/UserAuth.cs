using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImmigrationHack.Services.src.Data.Entities
{

    public class UserAuth
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

