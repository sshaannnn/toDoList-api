
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toDoList_api.Data;
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
        private readonly DataContext _context;
        public TodoListService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetTodoListDto>>> AddTodoList(AddTodoListDto newTodoList)
        {
            ServiceResponse<List<GetTodoListDto>> serviceResponse = new ServiceResponse<List<GetTodoListDto>>();
            TodoList todoList = _mapper.Map<TodoList>(newTodoList);
            await _context.TodoLists.AddAsync(todoList);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.TodoLists.Select(c => _mapper.Map<GetTodoListDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTodoListDto>>> GetAllLists()
        {
            ServiceResponse<List<GetTodoListDto>> serviceResponse = new ServiceResponse<List<GetTodoListDto>>();
            List<TodoList> dbTodoLists = await _context.TodoLists.ToListAsync();
            serviceResponse.Data = (dbTodoLists.Select(c => _mapper.Map<GetTodoListDto>(c))).ToList();
            return serviceResponse;
        }
    }
}