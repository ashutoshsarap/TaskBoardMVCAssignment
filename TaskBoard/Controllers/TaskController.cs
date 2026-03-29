using Microsoft.AspNetCore.Mvc;
using TaskBoard.Service;
using TaskBoard.Models;
namespace TaskBoard.Controllers
{
    public class TaskController : Controller
    {

        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public IActionResult Index()
        {
            List<TaskDTO> taskDTOs = _taskService.GetAllTasks();
            return View(taskDTOs);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TaskDTO task)
        {
            if (ModelState.IsValid)
            {
                _taskService.AddTask(task);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete()
        {

        }


    }
}
