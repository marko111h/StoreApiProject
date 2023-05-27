using StoreApiProject.Models;

namespace StoreApiProject.Services
{
    public class StateOfStoragesRepository : IStateOfStoragesRepository
    {
        private AppDbContext _stateOfStorageContext;


        public StateOfStoragesRepository(AppDbContext stateOfStorageContext)
        {
            _stateOfStorageContext = stateOfStorageContext;
        }


        public ICollection<StateOfStorages> GetStateOfStorages()
        {
            return _stateOfStorageContext.StateOfStorage.ToList();
        }

      
    }
}
