using Microsoft.EntityFrameworkCore;
using toDoList_api.Models;

namespace toDoList_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TodoList> TodoLists { get; set; }

    }
}