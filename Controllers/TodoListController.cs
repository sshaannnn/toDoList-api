using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("GetAll")]
        public IActionResult GetAllLists()
        {
            return Ok(_todoListService.GetAllLists());
        }
    }
}