using StoreApiProject.Models;

namespace StoreApiProject.Services
{
    public class StoragesRepository : IStoragesRepository
    {
        private AppDbContext _storagesContext;

        public StoragesRepository(AppDbContext storagesContext)
        {
            _storagesContext = storagesContext;
        }

    
        public ICollection<Storages> GetStorages()
        {
            return _storagesContext.Storage.ToList();
        }
    }
}
