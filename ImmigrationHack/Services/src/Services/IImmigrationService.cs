using ImmigrationHack.Services.src.Data.Entities;

namespace ImmigrationHack.Services.src.Service
{
    public interface IImmigrationService
    {
        User GetUserByEmail(string emailId);
        Task<User> CreateUser(User user);
        Task<bool> DeleteUser(Guid id);
        Task<User> UpdateUser(Guid id, User user);
        Task<User> GetUser(Guid id);
        Task<UserDocument> UploadDocument(UserDocument req);
        bool AuthenticateUser(string emailId, string password);
    }
}
