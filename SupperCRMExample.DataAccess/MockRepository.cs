using MFramework.Services.FakeData;
using NETCore.Encrypt.Extensions;
using SupperCRMExample.Common;
using SupperCRMExample.DataAccess.Context;
using System;
using System.Linq;

namespace SupperCRMExample.DataAccess
{
    public interface IMockRepository
    {
        void GenerateFakeData();
        void AddAdmin(string email, string name, string username, string password);
    }

    public class MockRepository : IMockRepository
    {
        private readonly DatabaseContext _context;

        public MockRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddAdmin(string email, string name, string username, string password)
        {
            if (_context.Users.Any(x => x.Username == email)) return;

            _context.Users.Add(new Entities.User
            {
                Email = email,
                Password = (Constants.PasswordSalt + password).MD5(),
                Name = name,
                Username = username,
                Role = Constants.Role_Admin,
                CreatedAt = DateTime.Now
            });


            _context.SaveChanges();
        }

        public void GenerateFakeData()
        {
            for (int i = 0; i < 10; i++)
            {
                string email = NetworkData.GetEmail();

                _context.Users.Add(new Entities.User
                {
                    Email = email,
                    Password = (Constants.PasswordSalt + "123456").MD5(),
                    Name = NameData.GetFullName(),
                    Username = email.Split('@')[0],
                    Role = Constants.Role_User,
                    CreatedAt = DateTimeData.GetDatetime(new DateTime(2021, 1, 1), DateTime.Now)
                });
            }

            _context.SaveChanges();

            var users = _context.Users.ToList();

            for (int i = 0; i < 1000; i++)
            {
                _context.Issues.Add(new Entities.Issue
                {
                    Summary = TextData.GetSentence(),
                    DueDate = DateTimeData.GetDatetime(new DateTime(2021, 1, 1), DateTime.Now),
                    Completed = BooleanData.GetBoolean(),
                    UserId = CollectionData.GetElement(users).Id,
                    CreatedAt = DateTimeData.GetDatetime(new DateTime(2021, 1, 1), DateTime.Now)
                });
            }

            _context.SaveChanges();

            for (int i = 0; i < 100; i++)
            {
                _context.Clients.Add(new Entities.Client
                {
                    Email = NetworkData.GetEmail(),
                    Description = TextData.GetSentence(),
                    Name = NameData.GetFullName(),
                    Phone = PhoneNumberData.GetPhoneNumber(),
                    IsCorporate = BooleanData.GetBoolean(),
                    CreatedAt = DateTimeData.GetDatetime(new DateTime(2021, 1, 1), DateTime.Now)
                });
            }

            _context.SaveChanges();

            var clients = _context.Clients.ToList();

            for (int i = 0; i < 2000; i++)
            {
                _context.Leads.Add(new Entities.Lead
                {
                    Summary = TextData.GetSentence(),
                    Desc = TextData.GetSentence(),
                    Price = NumberData.GetNumber(100, 5000),
                    Type = EnumData.GetElement<Entities.LeadType>(),
                    ClientId = CollectionData.GetElement(clients).Id,
                    UserId = CollectionData.GetElement(users).Id,
                    ModifiedAt = DateTimeData.GetDatetime(new DateTime(2021, 1, 1), DateTime.Now),
                    CreatedAt = DateTimeData.GetDatetime(new DateTime(2021, 1, 1), DateTime.Now)
                });
            }

            _context.SaveChanges();
        }


    }
}
