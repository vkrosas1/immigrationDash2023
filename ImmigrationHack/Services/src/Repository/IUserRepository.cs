using ImmigrationHack.Services.src.Data.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Path = ImmigrationHack.Services.src.Data.Entities.Path;

namespace ImmigrationHack.Services.src.Repository
{
    public interface IUserRepository
    {
        void Add<T>(T entity) where T : class;
        void Attach<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        ValueTask<T?> GetAsync<T>(Guid id) where T : class;
        EntityEntry<T> GetEntry<T>(T entity) where T : class;
        UserInfo? GetUserByKey(Guid? userId);
        UserInfo? GetUserByEmail(string? emailId);
        List<UserDocument>? GetUserDocumentsByuserId(Guid userId);
        Task<bool> SaveChangesAsync();
        void Update<T>(T entity) where T : class;
        List<List<Path>> GetEligiblePaths(Guid? userId);
    }
}
