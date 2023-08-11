using EcommerceCRUD.Models.DTO.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcommerceCRUD.Models.DTO.Input
{
    public class InputUser
    {
        [Required(ErrorMessage = "O nome é necessário!")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email é necessário!")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é necessária!")]
        [DisplayName("Senha")]
        public string Password { get; set; }

        public static User MapUserDtoToUser(InputUser input)
        {
            User user = new User()
            {
                Name = input.Name,
                Email = input.Email,
                HashedPassword = input.Password
            };

            return user;
        }
    }
}
