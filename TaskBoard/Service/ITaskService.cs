using TaskBoard.Models;

namespace TaskBoard.Service
{
    public interface ITaskService
    {
        List<TaskDTO> GetAllTasks();
        void AddTask(TaskDTO task);
        void UpdateTask(TaskDTO task);
        void DeleteTask(int id);
    }
}
