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

       public void DeleteStorage(int storageId)
        {
            var storage = _storagesContext.Storage.Find(storageId);
            if (storage != null)
            {
                _storagesContext.Storage.Remove(storage);
                _storagesContext.SaveChanges();
            }
        }
    }
}
