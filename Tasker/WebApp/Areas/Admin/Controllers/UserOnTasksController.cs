using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserOnTasksController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public UserOnTasksController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: UserOnTasks
        public async Task<IActionResult> Index()
        {
            var userOnTasks = await _uow.UserOnTasks.AllAsync();

            return View(userOnTasks);
        }

        // GET: UserOnTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnTask = await _uow.UserOnTasks.FindAsync(id);

            if (userOnTask == null)
            {
                return NotFound();
            }

            return View(userOnTask);
        }

        // GET: UserOnTasks/Create
        public async Task<IActionResult> Create()
        {
            var vm = new UserOnTaskCreateViewModel()
            {
                AppUserSelectList = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id", "FirstName"),
                TaskSelectList = new SelectList(await _uow.BaseRepository<Domain.Task>().AllAsync(), "Id", "Id"),
                TaskGiverSelectList = new SelectList(await _uow.BaseRepository<Domain.Task>().AllAsync(), "Id", "Id"),
                TaskerSelectList = new SelectList(await _uow.BaseRepository<Domain.Task>().AllAsync(), "Id", "Id")

            };
            
            return View(vm);
        }

        // POST: UserOnTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserOnTaskCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.UserOnTasks.AddAsync(vm.UserOnTask);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id",
                "FirstName", vm.UserOnTask.AppUserId);
            vm.TaskSelectList = new SelectList(await _uow.BaseRepository<Domain.Task>().AllAsync(), "Id", "Id", vm.UserOnTask.TaskId);
            vm.TaskerSelectList = new SelectList(await _uow.BaseRepository<Domain.Task>().AllAsync(), "Id", "Id", vm.UserOnTask.TaskerId);
            vm.TaskGiverSelectList = new SelectList(await _uow.BaseRepository<Domain.Task>().AllAsync(), "Id", "Id", vm.UserOnTask.TaskGiverId);

            return View(vm);
        }

        // GET: UserOnTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnTask = await _uow.UserOnTasks.FindAsync(id);
            if (userOnTask == null)
            {
                return NotFound();
            }
            
            var vm = new UserOnTaskEditViewModel()
            {
                AppUserSelectList = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id", "FirstName", userOnTask.AppUserId),
                TaskSelectList = new SelectList(await _uow.BaseRepository<Domain.Task>().AllAsync(), "Id", "Id", userOnTask.TaskId),
                TaskGiverSelectList = new SelectList(await _uow.BaseRepository<Domain.Task>().AllAsync(), "Id", "Id", userOnTask.TaskGiverId),
                TaskerSelectList = new SelectList(await _uow.BaseRepository<Domain.Task>().AllAsync(), "Id", "Id", userOnTask.TaskerId)

            };
            
            return View(vm);
        }

        // POST: UserOnTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserOnTaskEditViewModel vm)
        {
            if (id != vm.UserOnTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.UserOnTasks.Update(vm.UserOnTask);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id",
                "FirstName", vm.UserOnTask.AppUserId);
            vm.TaskSelectList = new SelectList(await _uow.BaseRepository<Domain.Task>().AllAsync(), "Id", "Id", vm.UserOnTask.TaskId);
            vm.TaskerSelectList = new SelectList(await _uow.BaseRepository<Domain.Task>().AllAsync(), "Id", "Id", vm.UserOnTask.TaskerId);
            vm.TaskGiverSelectList = new SelectList(await _uow.BaseRepository<Domain.Task>().AllAsync(), "Id", "Id", vm.UserOnTask.TaskGiverId);

            return View(vm);
        }

        // GET: UserOnTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnTask = await _uow.UserOnTasks.FindAsync(id);
            if (userOnTask == null)
            {
                return NotFound();
            }

            return View(userOnTask);
        }

        // POST: UserOnTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.UserOnTasks.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
