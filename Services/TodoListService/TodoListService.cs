
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using toDoList_api.Dto;
using toDoList_api.Models;

namespace toDoList_api.Services.TodoListService
{
    public class TodoListService : ITodoListService
    {
        private static List<TodoList> todoLists = new List<TodoList>
        {
        };
        private readonly IMapper _mapper;
        public TodoListService(IMapper mapper)
        {
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetTodoListDto>>> AddTodoList(AddTodoListDto newTodoList)
        {
            ServiceResponse<List<GetTodoListDto>> serviceResponse = new ServiceResponse<List<GetTodoListDto>>();
            todoLists.Add(_mapper.Map<TodoList>(newTodoList));
            serviceResponse.Data = (todoLists.Select(c => _mapper.Map<GetTodoListDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTodoListDto>>> GetAllLists()
        {
            ServiceResponse<List<GetTodoListDto>> serviceResponse = new ServiceResponse<List<GetTodoListDto>>();
            serviceResponse.Data = (todoLists.Select(c => _mapper.Map<GetTodoListDto>(c))).ToList();
            return serviceResponse;
        }
    }
}