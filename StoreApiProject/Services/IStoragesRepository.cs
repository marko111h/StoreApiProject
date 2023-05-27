using StoreApiProject.Models;

namespace StoreApiProject.Services
{
    public interface IStoragesRepository
    {
        ICollection<Storages> GetStorages();
    
    }
}
