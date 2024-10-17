using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TM.Core.Abstract;

namespace TM.Core.Entity
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Key]
        public int PKUserId { get; set; }

        public required string EMail { get; set; }
        public required string Password { get; set; }
    }
}
