
namespace API_ASP.NET_Core_Course.Dto
{
    public class TarefaDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsCompleted { get; set;}
        public DateTime DueDate { get; set; }
       
    }
}