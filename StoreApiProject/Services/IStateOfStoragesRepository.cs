using StoreApiProject.Models;

namespace StoreApiProject.Services
{
    public interface IStateOfStoragesRepository
    {
        ICollection<StateOfStorages> GetStateOfStorages();
    }
}
