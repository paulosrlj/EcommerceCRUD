using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceCRUD.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(80)]
        public String Name { get; set; }

        [Column("Email", TypeName = "nvarchar")]
        [MaxLength(80)]
        public String Email { get; set; }

        [Column("HashedPassword", TypeName = "nvarchar")]
        [MaxLength(80)]
        public String HashedPassword { get; set; }

    }
}
