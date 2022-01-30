using NETCore.Encrypt.Extensions;
using SupperCRMExample.Common;
using SupperCRMExample.DataAccess;
using SupperCRMExample.Entities;
using SupperCRMExample.Models;
using System.Linq;

namespace SupperCRMExample.Services
{
    public interface IUserService
    {
        User Authenticate(AuthenticateModel model);
        void Create(CreateUserModel model);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Authenticate(AuthenticateModel model)
        {
            model.Username = model.Username.Trim();
            model.Password = (Constants.PasswordSalt + model.Password).MD5();

            return _repository.GetAll(x =>
                x.Username.ToLower() == model.Username.ToLower() && x.Password == model.Password).FirstOrDefault();
        }

        public void Create(CreateUserModel model)
        {
            User user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Username = model.Username,
                Password = (Constants.PasswordSalt + model.Password).MD5(),
                Role = model.Role,
                Locked = model.Locked,
                CreatedAt = System.DateTime.Now
            };

            _repository.Add(user);
        }
    }
}
