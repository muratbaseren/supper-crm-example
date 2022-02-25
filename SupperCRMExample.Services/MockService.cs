using SupperCRMExample.DataAccess;

namespace SupperCRMExample.Services
{
    public interface IMockService
    {
        void RunFakeGenerator();
        void AddAdmin(string email, string name, string username, string password);
    }

    public class MockService : IMockService
    {
        private readonly IMockRepository _repository;

        public MockService(IMockRepository repository)
        {
            _repository = repository;
        }

        public void RunFakeGenerator()
        {
            _repository.GenerateFakeData();
        }

        public void AddAdmin(string email, string name, string username, string password)
        {
            _repository.AddAdmin(email, name, username, password);
        }
    }
}
