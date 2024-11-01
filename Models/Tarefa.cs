using System.ComponentModel.DataAnnotations;


namespace API_ASP.NET_Core_Course.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set;}
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsCompleted { get; set;}
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}