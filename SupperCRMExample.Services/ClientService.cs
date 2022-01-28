using SupperCRMExample.DataAccess;
using SupperCRMExample.Entities;
using SupperCRMExample.Models;
using System.Collections.Generic;

namespace SupperCRMExample.Services
{
    public interface IClientService
    {
        void Create(string name, string email);
        void Create(CreateCustomerModel model);
        List<Client> List();
        Client GetById(int id);
        void Update(int id, EditCustomerModel model);
        void Delete(int id);
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

        public void Create(CreateCustomerModel model)
        {
            Client client = new Client
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Locked = model.Locked,
                IsCorporate = model.IsCorporate,
                Description = model.Description,
                CreatedAt = System.DateTime.Now
            };

            _repository.Add(client);
        }

        public Client GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Update(int id, EditCustomerModel model)
        {
            Client client = _repository.Get(id);
            client.Name = model.Name;
            client.Email = model.Email;
            client.Description = model.Description;
            client.Phone = model.Phone;
            client.IsCorporate = model.IsCorporate;
            client.Locked = model.Locked;

            _repository.Update(client);
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
