namespace toDoList_api.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Task { get; set; } = "go to sleep";
        public bool State { get; set; } = false;
    }
}