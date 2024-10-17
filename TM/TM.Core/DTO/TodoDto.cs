namespace TM.Core.DTO
{
    public class TodoDto
    {
        public int PKTodoId { get; set; }
        public int FKUserId { get; set; }
        public string? UserEmail { get; set; }
        public required string Title { get; set; }
        public required string Detail { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string? DisplayPriority { get; set; }
        public string? DisplayStatus { get; set; }
        public int StoryPoint { get; set; }
    }
}
