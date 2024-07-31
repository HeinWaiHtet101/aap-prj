using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITodoRepository repo;

        public HomeController(ILogger<HomeController> logger, ITodoRepository repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        public async Task<IActionResult> CreateTodo(Todo model)
        {
            ViewBag.Action = model.Id == Guid.Empty ? "Create" : "Update";
            return View(model);
        }

        public async Task<IActionResult> Create(Todo model)
        {
            var result = await repo.AddAsync(
                model.Name,
                model.IsDone,
                model.StartDate,
                model.EndDate);
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            var model = await repo.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> GetTodo(string id)
        {
            var model = await repo.GetByIdAsync(Guid.Parse(id));
            if (model is null)
            {
                return this.RedirectToAction("Index");
            }

            return View(model.Todo);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var model = await repo.GetByIdAsync(Guid.Parse(id));
            if (model is null)
            {
                return RedirectToAction("Index");
            }

            return this.RedirectToAction("CreateTodo", model.Todo);
        }

        public async Task<IActionResult> Update(Todo model)
        {
            var result = await repo.UpdateAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var model = await repo.DeleteAsync(Guid.Parse(id));
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
