using ImmigrationHack.Services.src.Data;
using ImmigrationHack.Services.src.Data.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            return _context.UserDocuments.Where(m => m.UserId == userId).ToList();
        }

        public List<List<Data.Entities.Path>> GetEligiblePaths(Guid userId)
        {
            var userDocs = GetUserDocumentsByuserId(userId);
            var availablePaths = new List<List<Data.Entities.Path>>();
            foreach (var userDoc in userDocs)
            {
                List<List<Data.Entities.Path>> paths = GetPathsForDocType(userDoc.DocumentTypeId);
                foreach (var path in paths)
                {
                    if (path == null || path.Count == 0 || IsPathAlreadyAdded(path, availablePaths))
                    {
                        continue;
                    }
                    availablePaths.Add(path);
                    
                }
            }
            return availablePaths;
        }

        private bool IsPathAlreadyAdded(List<Path> path, List<List<Path>> availablePaths)
        {
            foreach (var availablepath in availablePaths)
            {
                if (path[0].Name == availablepath[0].Name)
                {
                    return true;
                }
            }
            return false;
        }

        private List<List<Data.Entities.Path>> GetPathsForDocType(Guid documentTypeId)
        {
            var path = GetAsync<Path>(documentTypeId).Result;
            List<List<Path>> listOfPaths = new List<List<Path>>();
            if(path == null || path.NextEligiblePaths?.ToList().Count == 0)
            {
                listOfPaths.Add (new List < Path> { path });
            }
            else
            {
                foreach (var nextEligiblePath in path.NextEligiblePaths)
                {
                    var subLists = GetPathsForDocType(path.DocumentTypeId);
                    foreach (var subList in subLists)
                    {
                        if (subList != null && subList.Count > 0)
                        {
                            List<Path> listpath = new List<Path>();
                            listpath.AddRange (subList);
                            listOfPaths.Add (listpath);
                        }
                    }
                }
            }
            return listOfPaths;


        }

        public List<List<Path>> GetEligiblePaths(Guid? userId)
        {
            throw new NotImplementedException();
        }
    }
}