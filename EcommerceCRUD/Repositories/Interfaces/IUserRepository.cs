using EcommerceCRUD.Models.DTO.Entities;
using EcommerceCRUD.Models.DTO.Input;

namespace EcommerceCRUD.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Get(Guid id);

        Task<User> Create(User user);

        Task Update(User user);

        Task Delete(Guid id);


    }
}
