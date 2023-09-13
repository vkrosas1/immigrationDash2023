using ImmigrationHack.Services.src.Data.Entities;
using ImmigrationHack.Services.src.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ImmigrationHack.Services.src
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

        public async Task<ActionResult<User>> CreateUser(User input)
        {
            var existingUser = repository.GetUserByEmail(input.Email);
            if(existingUser != null)
            {
                return new ObjectResult(new { error = "User Already Exists" }) { StatusCode = 500 };
            }
            repository.Add(input);
            if (await repository.SaveChangesAsync())
            {
                return new ObjectResult(input)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "Unable to create user" })
            {
                StatusCode = 500,

            };
        }

        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await repository.GetAsync<User>(id).AsTask();
            if (user != null)
            {
                return new ObjectResult(user)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "User Not Found" }) { StatusCode = 404 };
        }

        public async Task<ActionResult<User>> UpdateUser(Guid id, User updatedUser)
        {
            var existing = await GetUser(id);

            updatedUser.Id = id;
            repository.GetEntry(existing);

            repository.Update(updatedUser);
            if (await repository.SaveChangesAsync())
            {
                return new ObjectResult(true)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "Unable to update user" })
            {
                StatusCode = 500,

            };
        }

        public async Task<ActionResult<bool>> DeleteUser(Guid id)
        {
            var toDelete = await GetUser(id);
            repository.Delete(toDelete);
            if (await repository.SaveChangesAsync())
            {
                return new ObjectResult(true)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "Unable to Delete user" })
            {
                StatusCode = 500,

            };
        }

        public async Task<ActionResult<User>> GetUserByEmail(string emailId)
        {
            User user = repository.GetUserByEmail(emailId);
            if (user != null)
            {
                return new ObjectResult(user)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "User Not Found" }) { StatusCode = 404 };
        }

        public async Task<ActionResult<UserDocument>> UploadDocument(UserDocument input)
        {
            repository.Add(input);
            if(await repository.SaveChangesAsync())
            {
                return new ObjectResult(true)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "Unable to Upload Document" })
            {
                StatusCode = 500,

            };

        }

        public async Task<ActionResult<bool>> AuthenticateUser(string emailId, string password)
        {
            User user = repository.GetUserByEmail(emailId);
            if (user != null && user.Password.Equals(password))
            {
                return new ObjectResult(true)
                {
                    StatusCode = 200
                };
            }
            return user == null ? 
                new ObjectResult(new { error = "User doesnt exist" }){StatusCode = 404} :
                new ObjectResult(new { error = "Wrong password" }) { StatusCode = 401};
        }

        public async Task<ActionResult<List<UserDocument>>> GetAllDocuments(Guid userid)
        {
            var userDocuments = repository.GetUserDocumentsByuserId(userid);
             if(userDocuments == null || userDocuments.Count == 0)
             {
                 return new ObjectResult(new { error = "User doesnt exist" }) { StatusCode = 400 };
             }
             return new ObjectResult(userDocuments) { StatusCode = 200 };
        }
    }
}
