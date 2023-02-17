namespace TaskManagerApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public List<User> Users { get; set; }
        public StatusCode? StatusCode { get; set; }
        public string DetailDescription { get; set; }
    }
}
