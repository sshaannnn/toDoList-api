
using System.Collections.Generic;
using System.Threading.Tasks;
using toDoList_api.Dto;
using toDoList_api.Models;

namespace toDoList_api.Services.TodoListService
{
    public class TodoListService : ITodoListService
    {
        public async Task<ServiceResponse<List<GetTodoListDto>>> GetAllLists()
        {
            // ServiceResponse<List<TodoList>> serviceResponse = new ServiceResponse<List<GetTodoListDto>>();
            throw new System.NotImplementedException();
        }
    }
}