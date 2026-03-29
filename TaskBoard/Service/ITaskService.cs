using TaskBoard.Models;

namespace TaskBoard.Service
{
    public interface ITaskService
    {
        List<TaskDTO> GetAllTasks();
        TaskDTO GetTaskById(int id);
        void AddTask(TaskDTO task);
        void UpdateTask(TaskDTO task);
        void DeleteTask(int id);
    }
}
