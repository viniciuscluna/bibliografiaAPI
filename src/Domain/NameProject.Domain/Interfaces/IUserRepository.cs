using NameProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameProject.Domain.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        Task<IEnumerable<User>> SaveAll(IEnumerable<User> users);
        Task<IEnumerable<User>> GetAll();
    }
}
