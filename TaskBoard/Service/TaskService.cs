using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.RegularExpressions;
using TaskBoard.Models;
using TaskBoard.Repositories;

namespace TaskBoard.Service
{
    public class TaskService : ITaskService
    {

        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void AddTask(TaskDTO task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            Regex regex = new Regex(@"^\d+");
            // Check if the title starts with a number
            if (regex.IsMatch(task.Title))
            {
                throw new ArgumentException("Title should not start with a number");
            }
            
            TaskItem taskItem = new TaskItem
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CurrentStatus = task.CurrentStatus
            };
            _taskRepository.AddTask(taskItem);
            
        }

        public void DeleteTask(int id)
        {
            _taskRepository.DeleteTask(id);
        }

        public List<TaskDTO> GetAllTasks()
        {
            return _taskRepository.GetAllTasks().Select(task => new TaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CurrentStatus = task.CurrentStatus
            }).ToList();
        }

        public void UpdateTask(TaskDTO task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            Regex regex = new Regex(@"^\d+");
            // Check if the title starts with a number
            if (regex.IsMatch(task.Title))
            {
                throw new ArgumentException("Title should not start with a number");
            }
            
            TaskItem taskItem = new TaskItem
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CurrentStatus = task.CurrentStatus
            };
            _taskRepository.UpdateTask(taskItem);
        }


    }
}
