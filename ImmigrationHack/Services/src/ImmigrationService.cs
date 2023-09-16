using ImmigrationHack.Services.src.Data.DataTransferObjects;
using ImmigrationHack.Services.src.Data.Entities;
using ImmigrationHack.Services.src.Repository;
using Microsoft.AspNetCore.Mvc;

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
            var existing = await repository.GetAsync<User>(id).AsTask();
            if (existing == null)
            {
                return new ObjectResult(new { error = "Unable to find user" })
                {
                    StatusCode = 404,
                };
            }
            updatedUser.Id = id;
            repository.GetEntry<User>(existing).CurrentValues.SetValues(updatedUser);

            if (await repository.SaveChangesAsync())
            {
                return new ObjectResult(updatedUser)
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
            var toDelete = await repository.GetAsync<User>(id).AsTask();
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

        public async Task<ActionResult<List<UserDocumentResponse>>> GetAllDocuments(Guid userid)
        {
            var userDocuments = repository.GetUserDocumentsByuserId(userid);
            if(userDocuments == null || userDocuments.Count == 0)
            {
                return new ObjectResult(new { error = "User doesnt exist" }) { StatusCode = 400 };
            }
            List < UserDocumentResponse > response = new List < UserDocumentResponse >();

            foreach (var userDocument in userDocuments)
            {
                UserDocumentResponse userDocumentResponse = new UserDocumentResponse();
                userDocumentResponse.UserDocument = userDocument;
                var documentType = repository.GetAsync<DocumentType>(userDocument.DocumentTypeId).Result;
                userDocumentResponse.DocumentTypeName = documentType?.Name;
                response.Add(userDocumentResponse);
            }
             return new ObjectResult(response) { StatusCode = 200 };
        }

        public async Task<ActionResult<DocumentType>> AddDocumentType(DocumentType docType)
        {
            var existingDocType = repository.GetDocumentTypeByName(docType.Name);
            if (existingDocType != null)
            {
                return new ObjectResult(new { error = "Dcoument Type Already Exists" }) { StatusCode = 500 };
            }
            repository.Add(docType);
            if (await repository.SaveChangesAsync())
            {
                return new ObjectResult(docType)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "Unable to create documentType" })
            {
                StatusCode = 500,
            };
        }

        public async Task<ActionResult<Data.Entities.Path>> AddPath(Data.Entities.Path path)
        {
            var existing = repository.GetPathByName(path.Name);
            if (existing != null)
            {
                return new ObjectResult(new { error = "Path Already Exists" }) { StatusCode = 500 };
            }
            repository.Add(path);
            if (await repository.SaveChangesAsync())
            {
                return new ObjectResult(path)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "Unable to create path" })
            {
                StatusCode = 500,
            };
        }

        public async Task<ActionResult<Data.Entities.Form>> AddForm(Form form)
        {
            var existing = repository.GetPathByName(form.DocumentTypeName);
            if (existing != null)
            {
                return new ObjectResult(new { error = "Path Already Exists" }) { StatusCode = 500 };
            }
            repository.Add(form);
            if (await repository.SaveChangesAsync())
            {
                return new ObjectResult(form)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "Unable to create form" })
            {
                StatusCode = 500,
            };
        }

        public async Task<ActionResult<DocumentType>> GetDocumentTypeByName(string name)
        {
            var docType =  repository.GetDocumentTypeByName(name);
            if (docType != null)
            {
                return new ObjectResult(docType)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "DocumentType Not Found" }) { StatusCode = 404 };
        }

        public async Task<ActionResult<List<string>>> GetEligiblePaths(Guid userId)
        {
            var paths = repository.GetEligiblePaths(userId);
            if (paths != null && paths.Count > 0)
            {
                return new ObjectResult(paths)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "Eligible Paths Not Found for the User" }) { StatusCode = 404 };
        }

        public async Task<ActionResult<DocumentType>> GetDocumentType(Guid documentTypeId)
        {
            var docType = await repository.GetAsync<DocumentType>(documentTypeId);
            if (docType != null)
            {
                return new ObjectResult(docType)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "DocumentType Not Found" }) { StatusCode = 404 };
        }

        public async Task<ActionResult<UserDocument>> UpdateUserDocument(Guid userDocumentId, UserDocument userDocument)
        {
            var existing = await repository.GetAsync<UserDocument>(userDocumentId);
            if(existing == null)
            {
                return new ObjectResult(new { error = "Unable to find user document" })
                {
                    StatusCode = 404,
                };
            }
            userDocument.Id = userDocumentId;
            repository.GetEntry<UserDocument>(existing).CurrentValues.SetValues(userDocument);

            repository.Update<UserDocument>(userDocument);
            if (await repository.SaveChangesAsync())
            {
                return new ObjectResult(userDocument)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "Unable to update user" })
            {
                StatusCode = 500,
            };
        }


        public async Task<ActionResult<bool>> DeleteUserDocument(Guid id)
        {
            var toDelete = await repository.GetAsync<UserDocument>(id);
            if (toDelete == null)
            {
                return new ObjectResult(new { error = "Unable to find userdocument" })
                {
                    StatusCode = 404,
                };
            }
            repository.Delete<UserDocument>(toDelete);
            if (await repository.SaveChangesAsync())
            {
                return new ObjectResult(true)
                {
                    StatusCode = 200
                };
            }
            return new ObjectResult(new { error = "Unable to Delete userdocument" })
            {
                StatusCode = 500,
            };
        }
    }
}
