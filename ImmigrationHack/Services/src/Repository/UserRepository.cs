using ImmigrationHack.Services.src.Data;
using ImmigrationHack.Services.src.Data.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using Path = ImmigrationHack.Services.src.Data.Entities.Path;

namespace ImmigrationHack.Services.src.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public EntityEntry<T> GetEntry<T>(T entity) where T : class
        {
            return _context.Entry(entity);
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation(
                "Adding an object of type {type} to the context.",
                entity.GetType()
            );
            _context.Add(entity);
        }

        public void Attach<T>(T entity) where T : class
        {
            _logger.LogInformation(
                $"Attaching an object of type {entity.GetType()} to the context."
            );
            _context.Attach(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation(
                "Removing an object of type {type} to the context.",
                entity.GetType()
            );
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _logger.LogInformation(
                "Updating object of type {type} with the context.",
                entity.GetType()
            );
            _context.Update(entity);
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            _logger.LogInformation("Getting all with the context.");
            return _context.Set<T>();
        }

        public ValueTask<T?> GetAsync<T>(Guid id) where T : class
        {
            return _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempting to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        public User? GetUserByKey(Guid? userId)
        {
            var user = _context.Users.Where(m => m.Id == userId).FirstOrDefault();
            return user;
        }

        public User? GetUserByEmail(string? emailId)
        {
            var user = _context.Users.Where(m => m.Email == emailId).FirstOrDefault();
            return user;
        }

        public List<UserDocument>? GetUserDocumentsByuserId(Guid userId)
        {
            return _context.UserDocuments.Where(m => m.UserId == userId)?.ToList();
        }

        public List<string> GetEligiblePaths(Guid userId)
        {
            var userDocs = GetUserDocumentsByuserId(userId);
            var availablePaths = new HashSet<string>();
            if(userDocs == null || userDocs.Count == 0)
            {
                return new List<string>();
            }
            foreach (var userDoc in userDocs)
            {
                //adding in set to remove duplicate paths
                availablePaths.UnionWith(GetEligiblePathsForDocType(userDoc.DocumentTypeId));
            }

            List<string> sortedPaths = availablePaths.ToList().OrderBy(str => str.Length).ToList();
            List<string> paths = new List<string>();
            foreach(var sortedPath in sortedPaths)
            {
                bool isShortPathAvailable = false;
                foreach(var path in paths)
                {
                    /*
                     * Logic to tackle if paths available are
                     * p1 = GED,OPT,H1B,GC,C
                     * p2 = OPT,H1B,GC,C
                     * only p2 should be eligible path as user already has OPT
                     */
                    int index = sortedPath.IndexOf(path);
                    if(index == -1)
                    {
                        isShortPathAvailable = true;
                        break;
                    }
                }
                if (!isShortPathAvailable)
                {
                    paths.Add(sortedPath);
                }
            }
            return paths;
        }

        private List<string> GetEligiblePathsForDocType(Guid documentTypeId)
        {
            var docName = _context.DocumentTypes.Where(m => m.Id == documentTypeId).FirstOrDefault();

            List<string> availablePaths = new List<string>();
            if (docName == null)
            {
               return availablePaths;
            }
            List<Form> forms = _context.Forms.Where(f => f.DocumentTypeName.Equals(docName))?.ToList();

            if (forms == null || forms.Count == 0)
            {
                return availablePaths;
            }
            foreach (var form in forms)
            {
                if(form.EligiblePaths != null && form.EligiblePaths.Length > 0)
                {
                    availablePaths.Add(form.EligiblePaths);
                }
            }
            return availablePaths;
        }

        public DocumentType? GetDocumentTypeByName(string name)
        {
            return _context.DocumentTypes.Where(m => m.Name == name).FirstOrDefault();
        }

        public Path? GetPathByName(string name)
        {
            return null;
            //return _context.Path1s.Where(m => m.Name == name).FirstOrDefault();
        }
    }
}