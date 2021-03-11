
using System;
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
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public TodoListService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<GetTodoListDto>>> GetAllLists()
        {
            ServiceResponse<List<GetTodoListDto>> serviceResponse = new ServiceResponse<List<GetTodoListDto>>();
            List<TodoList> dbTodoLists = await _context.TodoLists.ToListAsync();
            serviceResponse.Data = (dbTodoLists.Select(c => _mapper.Map<GetTodoListDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoListDto>> GetSingleTodoList(GetSingleTodoListDto getSingleTodoList)
        {
            ServiceResponse<GetTodoListDto> serviceResponse = new ServiceResponse<GetTodoListDto>();
            try
            {
                TodoList dbTodoList = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == getSingleTodoList.Id);
                serviceResponse.Data = _mapper.Map<GetTodoListDto>(dbTodoList);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTodoListDto>>> AddTodoList(AddTodoListDto newTodoList)
        {
            ServiceResponse<List<GetTodoListDto>> serviceResponse = new ServiceResponse<List<GetTodoListDto>>();
            TodoList dbTodoList = _mapper.Map<TodoList>(newTodoList);
            await _context.TodoLists.AddAsync(dbTodoList);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.TodoLists.Select(c => _mapper.Map<GetTodoListDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoListDto>> UpdateTodoList(UpdateTodoListDto updateTodoList)
        {
            ServiceResponse<GetTodoListDto> serviceResponse = new ServiceResponse<GetTodoListDto>();
            try
            {
                TodoList dbTodoList = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == updateTodoList.Id);
                if (updateTodoList.Task == null)
                {
                    dbTodoList.Task = dbTodoList.Task;
                    dbTodoList.State = bool.Parse(updateTodoList.State);
                }
                else if (updateTodoList.State == null)
                {
                    dbTodoList.State = dbTodoList.State;
                    dbTodoList.Task = updateTodoList.Task;
                }
                else
                {
                    dbTodoList.Task = updateTodoList.Task;
                    dbTodoList.State = bool.Parse(updateTodoList.State);
                }
                _context.TodoLists.Update(dbTodoList);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetTodoListDto>(dbTodoList);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoListDto>> DeleteTodoList(DeleteTodoListDto deleteTodoList)
        {
            ServiceResponse<GetTodoListDto> serviceResponse = new ServiceResponse<GetTodoListDto>();
            try
            {
                TodoList dbTodoList = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == deleteTodoList.Id);
                _context.TodoLists.Remove(dbTodoList);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetTodoListDto>(dbTodoList);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }
    }
}