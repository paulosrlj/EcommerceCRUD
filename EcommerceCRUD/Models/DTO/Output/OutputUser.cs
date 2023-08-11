using EcommerceCRUD.Models.DTO.Entities;
using System.ComponentModel;

namespace EcommerceCRUD.Models.DTO.Output
{
    public class OutputUser
    {
        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        public static OutputUser MapUserToUserOutput(User user)
        {
            OutputUser output = new OutputUser()
            {
                Name = user.Name,
                Email = user.Email
            };

            return output;
        }
    }
}
