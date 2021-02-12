using NameProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameProject.Domain.Interfaces
{
    public interface INameConstructorService : IDisposable
    {
        Task<IEnumerable<User>> ConvertNames(IEnumerable<string> names);
        Task<IEnumerable<User>> GetAllNames();
    }
}
