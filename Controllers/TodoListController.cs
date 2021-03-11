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
            return Ok(await _todoListService.GetAllLists());
        }

        [HttpPost("AddTodoList")]
        public async Task<IActionResult> AddTodoList(AddTodoListDto newTodoList)
        {
            return Ok(await _todoListService.AddTodoList(newTodoList));
        }

        [HttpPost("GetSingleTodoList")]
        public async Task<IActionResult> GetSingleTodoList(GetSingleTodoListDto getSingleTodoList)
        {
            ServiceResponse<GetTodoListDto> response = await _todoListService.GetSingleTodoList(getSingleTodoList);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("DeleteTodoList")]
        public async Task<IActionResult> DeleteTodoList(DeleteTodoListDto deleteTodoList)
        {
            ServiceResponse<GetTodoListDto> response = await _todoListService.DeleteTodoList(deleteTodoList);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}