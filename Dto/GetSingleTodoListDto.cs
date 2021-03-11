namespace toDoList_api.Dto
{
    public class GetSingleTodoListDto
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public string State { get; set; }
    }
}