using EcommerceCRUD.Models.DTO.Entities;
using EcommerceCRUD.Models.DTO.Input;

namespace EcommerceCRUD.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Create(User user);

        Task<User> Get(string id);

        Task Update(string id, InputUser inputUser);

        Task Delete(string id);
    }
}
