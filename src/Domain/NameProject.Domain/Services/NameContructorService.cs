using NameProject.Domain.Entities;
using NameProject.Domain.Interfaces;
using NameProject.Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameProject.Domain.Services
{
    public class NameContructorService : INameConstructorService
    {
        private readonly IUserRepository _repository;
        public NameContructorService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> ConvertNames(IEnumerable<string> names)
        {
            names = names.ConvertNames();

            var users = names.Select(s => new User
            {
                Name = s
            });
            users = await _repository.SaveAll(users);

            return users;
        }

        public async Task<IEnumerable<User>> GetAllNames()
        {
            return await _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

      
    }
}
