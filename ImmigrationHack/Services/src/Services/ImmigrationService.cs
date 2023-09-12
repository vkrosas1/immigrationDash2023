using AutoMapper;
using ImmigrationHack.Services.src.Data.Entities;
using ImmigrationHack.Services.src.Repository;
using ImmigrationHack.Services.src.Service;

namespace ImmigrationHack.Services.src.Services
{
    public class ImmigrationService : IImmigrationService
    {
        private readonly IUserRepository repository;

        public ImmigrationService(
            IUserRepository repository
        )
        {
            this.repository = repository;
        }

        public async Task<User> CreateUser(User input)
        {
            repository.Add(input);
            await repository.SaveChangesAsync();
            return input;
        }

        public async Task<User> GetUser(Guid id)
        {
            var user = await repository.GetAsync<User>(id).AsTask();
            if (user == null)
            {
                throw new KeyNotFoundException($"Failed to retrieve user id={id}");
            }
            return user;
        }

        public async Task<User> UpdateUser(Guid id, User updatedUser)
        {
            var existing = await GetUser(id);

            updatedUser.Id = id;
            repository.GetEntry(existing);

            repository.Update(updatedUser);
            return updatedUser;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var toDelete = await GetUser(id);
            repository.Delete(toDelete);
            await repository.SaveChangesAsync();
            return true;
        }

        public User GetUserByEmail(string emailId)
        {
            User user = repository.GetUserByEmail(emailId);
            if (user == null)
            {
                throw new KeyNotFoundException($"Failed to retrieve user emailId={emailId}");
            }
            return user;
        }

        public Task<UserDocument> UploadDocument(UserDocument req)
        {
            throw new NotImplementedException();
        }
    }
}
