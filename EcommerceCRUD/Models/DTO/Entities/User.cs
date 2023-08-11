using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceCRUD.Models.DTO.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(80)]
        public string Name { get; set; }

        [Column("Email", TypeName = "nvarchar")]
        [MaxLength(80)]
        public string Email { get; set; }

        [Column("HashedPassword", TypeName = "nvarchar")]
        [MaxLength(80)]
        public string HashedPassword { get; set; }

    }
}
