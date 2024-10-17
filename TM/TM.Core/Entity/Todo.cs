using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TM.Core.Abstract;
using TM.Core.Enum;

namespace TM.Core.Entity
{
    [Table("Todos")]
    public class Todo : BaseEntity
    {
        [Key]
        public int PKTodoId { get; set; }

        public string Title { get; set; }
        public string Detail { get; set; }
        public int StoryPoint { get; set; }
        public TodoPriority Priority { get; set; }
        public TodoStatus Status { get; set; }

        [ForeignKey("PKUserId")]
        public int FKUserId { get; set; }
    }
}
