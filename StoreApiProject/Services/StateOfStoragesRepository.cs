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


        public ICollection<StateOfStorage> GetStateOfStorages()
        {
            return _stateOfStorageContext.StateOfStorages.ToList();
        }

        public void DeleteStateOfStorage(int stateOfStorageId)
        {
            var stateOfStorage = _stateOfStorageContext.StateOfStorages.FirstOrDefault(s => s.StateOfStorageId == stateOfStorageId);

            if (stateOfStorage != null)
            {
                _stateOfStorageContext.StateOfStorages.Remove(stateOfStorage);
                _stateOfStorageContext.SaveChanges();
            }
        }


    }
}
