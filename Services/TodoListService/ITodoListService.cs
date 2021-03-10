using System.Collections.Generic;
using toDoList_api.Models;

namespace toDoList_api.Services.TodoListService
{
    public interface ITodoListService
    {
        Task<List<TodoList>> GetAllLists();
    }
}