using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TasksController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public TasksController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var tasks = await _uow.Tasks.AllAsync();

            return View(tasks);
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _uow.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public async Task<IActionResult> Create()
        {
            var vm = new TaskCreateViewModel()
            {
                AppUserSelectList = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id", "FirstName"),
                TaskTypeSelectList = new SelectList(await _uow.BaseRepository<TaskType>().AllAsync(), "Id", "Id"),

            };

            return View(vm);
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.Tasks.AddAsync(vm.Task);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id",
                "FirstName", vm.Task.AppUserId);
            vm.TaskTypeSelectList = new SelectList(await _uow.BaseRepository<TaskType>().AllAsync(), "Id",
                "Id", vm.Task.TaskTypeId);

            return View(vm);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _uow.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            
            var vm = new TaskEditViewModel()
            {
                AppUserSelectList = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id", "FirstName", task.AppUserId),
                TaskTypeSelectList = new SelectList(await _uow.BaseRepository<TaskType>().AllAsync(), "Id", "Id", task.TaskTypeId),

            };

            return View(vm);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskEditViewModel vm)
        {
            if (id != vm.Task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Tasks.Update(vm.Task);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id",
                "FirstName", vm.Task.AppUserId);
            vm.TaskTypeSelectList = new SelectList(await _uow.BaseRepository<TaskType>().AllAsync(), "Id",
                "Id", vm.Task.TaskTypeId);
            
            return View(vm);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _uow.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Tasks.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
