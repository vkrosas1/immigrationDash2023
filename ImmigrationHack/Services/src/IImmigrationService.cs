using ImmigrationHack.Services.src.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Path = ImmigrationHack.Services.src.Data.Entities.Path;

namespace ImmigrationHack.Services.src
{
    public interface IImmigrationService
    {
        Task<ActionResult<User>> GetUserByEmail(string emailId);
        Task<ActionResult<User>> CreateUser(User user);
        Task<ActionResult<bool>> DeleteUser(Guid id);
        Task<ActionResult<User>> UpdateUser(Guid id, User user);
        Task<ActionResult<User>> GetUser(Guid id);
        Task<ActionResult<UserDocument>> UploadDocument(UserDocument req);
        Task<ActionResult<List<UserDocument>>> GetAllDocuments(Guid userid);
        Task<ActionResult<bool>> AuthenticateUser(string emailId, string password);
        Task<ActionResult<DocumentType>> AddDocumentType(DocumentType docType);
        Task<ActionResult<Path>> AddPath(Path path);
        Task<ActionResult<DocumentType>> GetDocumentTypeByName (string name);
    }
}
