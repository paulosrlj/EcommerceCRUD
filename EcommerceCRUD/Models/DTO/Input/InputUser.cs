using EcommerceCRUD.Entities;

namespace EcommerceCRUD.Models.DTO.Input
{
    public class InputUser
    {

        public String Name { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

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
