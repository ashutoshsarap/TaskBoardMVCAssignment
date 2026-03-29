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
            int cnt=taskDTOs.Count;
            return View(taskDTOs);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TaskDTO task)
        {
            if(ModelState.IsValid)
            {
                _taskService.AddTask(task);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _taskService.DeleteTask(id);
            return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            TaskDTO taskDto = _taskService.GetTaskById(id);
            if (taskDto == null)
            {
                return NotFound();
            }
            return View(taskDto);
        }

        [HttpPost]
        public IActionResult Update(TaskDTO task)
        {
            if (ModelState.IsValid)
            {
                _taskService.UpdateTask(task);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
