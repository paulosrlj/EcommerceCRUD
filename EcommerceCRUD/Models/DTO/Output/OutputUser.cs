using EcommerceCRUD.Models.DTO.Entities;
using System.ComponentModel;

namespace EcommerceCRUD.Models.DTO.Output
{
    public class OutputUser
    {
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        public static OutputUser MapUserToUserOutput(User user)
        {
            OutputUser output = new OutputUser()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return output;
        }

        public override bool Equals(object? obj)
        {
            return obj is OutputUser user &&
                   Id.Equals(user.Id) &&
                   Name == user.Name &&
                   Email == user.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Email);
        }
    }
}
