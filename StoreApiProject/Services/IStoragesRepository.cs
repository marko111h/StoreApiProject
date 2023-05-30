using StoreApiProject.Models;

namespace StoreApiProject.Services
{
    public interface IStoragesRepository
    {
         void DeleteStorage(int storageId);
        ICollection<Storage> GetStorages();
    
    }
}
