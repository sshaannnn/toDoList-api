namespace toDoList_api.Dto
{
    public class UpdateTodoListDto
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public string State { get; set; }
    }
}