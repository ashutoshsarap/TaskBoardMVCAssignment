using TaskBoard.Models;

namespace TaskBoard.Repositories
{
    public interface ITaskRepository
    {
        List<TaskItem> GetAllTasks();
        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(int id);
    }
}
