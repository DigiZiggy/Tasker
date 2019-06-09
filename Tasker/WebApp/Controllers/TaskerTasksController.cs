using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class TaskerTasksController : Controller
    {
        private readonly IAppBLL _bll;

        public TaskerTasksController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: TaskerTasks
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Tasks.AllAsync());
        }

        // GET: TaskerTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskerTask = await _bll.Tasks.FindAsync(id);

            if (taskerTask == null)
            {
                return NotFound();
            }

            return View(taskerTask);
        }

        // GET: TaskerTasks/Create
        public async Task<IActionResult> Create()
        {
            var vm = new TaskCreateViewModel()
            {
                AddressSelectList = new SelectList(await _bll.Addresses.AllAsync(), 
                    nameof(BLL.App.DTO.Address.Id), 
                    nameof(BLL.App.DTO.Address.Id))
            };

            return View(vm);
        }


        // POST: TaskerTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.Tasks.Add(vm.TaskerTask);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.AddressSelectList = new SelectList(await _bll.Addresses.AllAsync(), 
                nameof(BLL.App.DTO.Address.Id),
                nameof(BLL.App.DTO.Address.Id), 
                vm.TaskerTask.AddressId);

            return View(vm);
        }

        // GET: TaskerTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskerTask = await _bll.Tasks.FindAsync(id);
            if (taskerTask == null)
            {
                return NotFound();
            }

            var vm = new TaskEditViewModel()
            {
                AddressSelectList = new SelectList(await _bll.Addresses.AllAsync(), 
                    nameof(BLL.App.DTO.Address.Id), 
                    nameof(BLL.App.DTO.Address.Id), 
                    taskerTask.AddressId)
            };

            return View(vm);
        }

        // POST: TaskerTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskEditViewModel vm)
        {
            if (id != vm.TaskerTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Tasks.Update(vm.TaskerTask);
                await _bll.SaveChangesAsync();
     
                return RedirectToAction(nameof(Index));
            }
            vm.AddressSelectList = new SelectList(await _bll.Addresses.AllAsync(), 
                nameof(BLL.App.DTO.Address.Id),
                nameof(BLL.App.DTO.Address.Id), 
                vm.TaskerTask.AddressId);
            
            return View(vm);

        }

        // GET: TaskerTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskerTask = await _bll.Tasks.FindAsync(id);

            if (taskerTask == null)
            {
                return NotFound();
            }

            return View(taskerTask);
        }

        // POST: TaskerTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.Tasks.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
