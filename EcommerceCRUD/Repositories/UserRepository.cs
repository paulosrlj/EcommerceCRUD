using EcommerceCRUD.Database;
using EcommerceCRUD.Models.DTO.Entities;

namespace EcommerceCRUD.Repositories
{
    public class UserRepository
    {
        private readonly EcommerceCRUDContext _ctx;

        public UserRepository(EcommerceCRUDContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> Create(User user)
        {
            await _ctx.AddAsync(user);
            await _ctx.SaveChangesAsync();

            return user;
        }
    }
}
