using AutoMapper;
using toDoList_api.Dto;
using toDoList_api.Models;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TodoList, GetTodoListDto>();
            CreateMap<AddTodoListDto, TodoList>();
        }

    }
}