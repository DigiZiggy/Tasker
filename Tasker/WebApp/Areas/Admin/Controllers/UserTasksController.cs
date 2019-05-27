using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserTasksController : Controller
    {
        private readonly IAppBLL _bll;

        public UserTasksController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: UserTasks
        public async Task<IActionResult> Index()
        {
            var userTasks = await _bll.UserTasks.AllAsync();

            return View(userTasks);
        }

        // GET: UserTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTask = await _bll.UserTasks.FindAllIncludedAsync(id);

            if (userTask == null)
            {
                return NotFound();
            }

            return View(userTask);
        }

        // GET: UserTasks/Create
        public async Task<IActionResult> Create()
        {
            var vm = new UserTaskCreateViewModel()
            {
                TaskGiverSelectList = new SelectList(await _bll.Tasks.AllAsync(), nameof(Task.Id), nameof(Task.Id)),
                TaskerSelectList = new SelectList(await _bll.Tasks.AllAsync(), nameof(Task.Id), nameof(Task.Id))

            };          
            return View(vm);
        }

        // POST: UserTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserTaskCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.UserTasks.AddAsync(vm.UserTask);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.TaskerSelectList = new SelectList(await _bll.Tasks.AllAsync(), nameof(Task.Id), 
                nameof(Task.Id), vm.UserTask.TaskerId);
            vm.TaskGiverSelectList = new SelectList(await _bll.Tasks.AllAsync(), nameof(Task.Id), 
                nameof(Task.Id), vm.UserTask.TaskGiverId);

            return View(vm);
        }

        // GET: UserTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTask = await _bll.UserTasks.FindAsync(id);
            if (userTask == null)
            {
                return NotFound();
            }
            var vm = new UserTaskEditViewModel()
            {
                TaskGiverSelectList = new SelectList(await _bll.Tasks.AllAsync(), nameof(Task.Id), 
                    nameof(Task.Id), userTask.TaskGiverId),
                TaskerSelectList = new SelectList(await _bll.Tasks.AllAsync(), nameof(Task.Id), 
                    nameof(Task.Id), userTask.TaskerId)
            };
            
            return View(vm);
        }

        // POST: UserTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserTaskEditViewModel vm)
        {
            if (id != vm.UserTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.UserTasks.Update(vm.UserTask);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            vm.TaskerSelectList = new SelectList(await _bll.Tasks.AllAsync(), nameof(Task.Id), 
                nameof(Task.Id), vm.UserTask.TaskerId);
            vm.TaskGiverSelectList = new SelectList(await _bll.Tasks.AllAsync(), nameof(Task.Id), 
                nameof(Task.Id), vm.UserTask.TaskGiverId);

            return View(vm);
        }

        // GET: UserTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTask = await _bll.UserTasks.FindAllIncludedAsync(id);

            if (userTask == null)
            {
                return NotFound();
            }

            return View(userTask);
        }

        // POST: UserTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.UserTasks.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
