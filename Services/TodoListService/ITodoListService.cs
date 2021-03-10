using System.Collections.Generic;
using System.Threading.Tasks;
using toDoList_api.Dto;
using toDoList_api.Models;

namespace toDoList_api.Services.TodoListService
{
    public interface ITodoListService
    {
        Task<ServiceResponse<List<GetTodoListDto>>> GetAllLists();
        Task<ServiceResponse<List<GetTodoListDto>>> AddTodoList(AddTodoListDto newTodoList);

    }
}