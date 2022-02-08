using SupperCRMExample.DataAccess;

namespace SupperCRMExample.Services
{
    public interface IMockService
    {
        void RunFakeGenerator();
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
    }
}
