using ImmigrationHack.Services.src.Data.DataTransferObjects;
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
        Task<ActionResult<List<UserDocumentResponse>>> GetAllDocuments(Guid userid);
        Task<ActionResult<bool>> AuthenticateUser(string emailId, string password);
        Task<ActionResult<DocumentType>> AddDocumentType(DocumentType docType);
        Task<ActionResult<Path>> AddPath(Path path);
        Task<ActionResult<Form>> AddForm(Form form);
        Task<ActionResult<DocumentType>> GetDocumentType(Guid documentTypeId);
        Task<ActionResult<DocumentType>> GetDocumentTypeByName (string name);
        Task<ActionResult<List<string>>> GetEligiblePaths(Guid userId);
        Task<ActionResult<UserDocument>> UpdateUserDocument(Guid userDocumentId, UserDocument userDocument);
        Task<ActionResult<bool>> DeleteUserDocument(Guid id);
    }
}
