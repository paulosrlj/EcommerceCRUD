using EcommerceCRUD.Database;
using EcommerceCRUD.Models.DTO.Entities;
using EcommerceCRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCRUD.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EcommerceCRUDContext _ctx;

        public UserRepository(EcommerceCRUDContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> Get(Guid id)
        {
            var user = await _ctx.Users.FindAsync(id);
            return user;
        }

        public async Task<User> Create(User user)
        {
            await _ctx.AddAsync(user);
            await _ctx.SaveChangesAsync();

            return user;
        }

        public async Task Update(User user)
        {
            _ctx.Update(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var user = await Get(id);

            _ctx.Users.Remove(user);

            await _ctx.SaveChangesAsync();
        }
    }
}
