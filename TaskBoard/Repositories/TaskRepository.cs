using TaskBoard.Data;
using TaskBoard.Models;
using System.Linq;

namespace TaskBoard.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _db;

        //Performing Dependency inj ection to get the instance of ApplicationDbContext
        public TaskRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddTask(TaskItem task)
        {
            _db.Add(task);
            _db.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            _db.Remove(id);
            _db.SaveChanges();
        }

        public List<TaskItem> GetAllTasks()
        {
            return _db.TaskItems.ToList();
        }

        public void UpdateTask(TaskItem task)
        {
            _db.Update(task);
            _db.SaveChanges();
        }
    }
}
