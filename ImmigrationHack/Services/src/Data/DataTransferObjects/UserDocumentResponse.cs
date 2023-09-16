using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using ImmigrationHack.Services.src.Data.Entities;

namespace ImmigrationHack.Services.src.Data.DataTransferObjects
{
    public class UserDocumentResponse
    {
        public UserDocument UserDocument { get; set; }
        public string DocumentTypeName { get; set; }
    }
}
