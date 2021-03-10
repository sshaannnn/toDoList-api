using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using toDoList_api.Dto;
using toDoList_api.Models;
using toDoList_api.Services.TodoListService;

namespace toDoList_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListService _todoListService;


        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        private static List<TodoList> todoLists = new List<TodoList>
        {

        };

        [HttpGet("GetAllTodoList")]
        public async Task<IActionResult> GetAllLists()
        {
            // return Ok(_todoListService.GetAllLists());
            return Ok(await _todoListService.GetAllLists());
        }

        [HttpPost("AddTodoList")]
        public async Task<IActionResult> AddTodoList(AddTodoListDto newTodoList)
        {
            return Ok(await _todoListService.AddTodoList(newTodoList));
        }
    }
}