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

    
        public ICollection<Storage> GetStorages()
        {
            return _storagesContext.Storages.ToList();
        }

       public void DeleteStorage(int storageId)
        {
            var storage = _storagesContext.Storages.Find(storageId);
            if (storage != null)
            {
                _storagesContext.Storages.Remove(storage);
                _storagesContext.SaveChanges();
            }
        }
    }
}
