using SupperCRMExample.DataAccess;
using SupperCRMExample.Entities;
using System.Collections.Generic;

namespace SupperCRMExample.Services
{
    public interface IClientService
    {
        void Create(string name, string email);
        List<Client> List();
    }

    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public List<Client> List()
        {
            return _repository.GetAll();
        }

        public void Create(string name, string email)
        {
            Client client = new Client
            {
                Name = name,
                Email = email,
                CreatedAt = System.DateTime.Now
            };

            _repository.Add(client);
        }
    }
}
