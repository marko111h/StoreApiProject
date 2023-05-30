using StoreApiProject.Models;

namespace StoreApiProject.Services
{
    public interface IStateOfStoragesRepository
    {
        ICollection<StateOfStorage> GetStateOfStorages();

        void DeleteStateOfStorage(int stateOfStorageId);

    }
}
