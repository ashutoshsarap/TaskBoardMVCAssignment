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
            //Checking if the task exists before deleting
            TaskItem existingTask = _taskRepository.GetTaskById(id);

            if (existingTask == null)
            {
                throw new ArgumentException($"Task with Id {id} does not exist");
            }

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
            //Checking if the task exists before updating
            TaskItem existingTask = _taskRepository.GetTaskById(task.Id);

            if (existingTask == null)
            {
                throw new ArgumentException($"Task with Id {task.Id} does not exist");
            }

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

            //Mapping the updated values to the existing task
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.CurrentStatus = task.CurrentStatus;

            //NOTE : Do not create a new TaskItem object here, as it will be treated as a new entity by the repository and may lead to conflict like duplicate entries.
            //Do not map the ID from the DTO to existingTask, as it will cause issues with the repository's tracking of entities. Instead, update the existing TaskItem directly and then call the UpdateTask method to save the changes.
            _taskRepository.UpdateTask(existingTask);
        }

        public TaskDTO GetTaskById(int id)
        {
            TaskItem taskItem = _taskRepository.GetTaskById(id);
            if (taskItem == null)
            {
                throw new ArgumentException($"Task with Id {id} does not exist");
            }
            return new TaskDTO
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                CurrentStatus = taskItem.CurrentStatus
            };

        }
    }

}
