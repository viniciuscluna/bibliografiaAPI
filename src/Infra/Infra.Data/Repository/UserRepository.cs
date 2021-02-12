using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NameProject.Domain.Entities;
using NameProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly NameProjectContext _context;
        public UserRepository(NameProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<IEnumerable<User>> SaveAll(IEnumerable<User> users)
        {
            _context.User.AddRange(users);
            await _context.SaveChangesAsync();
            return users;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
