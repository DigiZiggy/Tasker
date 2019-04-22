using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserInGroupsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public UserInGroupsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: UserInGroups
        public async Task<IActionResult> Index()
        {
            var userInGroups = await _uow.UserInGroups.AllAsync();

            return View(userInGroups);
        }

        // GET: UserInGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInGroup = await _uow.UserInGroups.FindAsync(id);

            if (userInGroup == null)
            {
                return NotFound();
            }

            return View(userInGroup);
        }

        // GET: UserInGroups/Create
        public async Task<IActionResult> Create()
        {
            var vm = new UserInGroupCreateViewModel()
            {
                UserSelectList = new SelectList(await _uow.BaseRepository<User>().AllAsync(), "Id", "Id"),
                UserGroupSelectList = new SelectList(await _uow.BaseRepository<UserGroup>().AllAsync(), "Id", "Id"),
            };
            
            return View(vm);
        }

        // POST: UserInGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserInGroupCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.UserInGroups.AddAsync(vm.UserInGroup);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.UserSelectList = new SelectList(await _uow.BaseRepository<User>().AllAsync(), "Id",
                "Id", vm.UserInGroup.UserId);
            vm.UserGroupSelectList = new SelectList(await _uow.BaseRepository<UserGroup>().AllAsync(), "Id", "Id", vm.UserInGroup.UserGroupId);

            return View(vm);
        }

        // GET: UserInGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInGroup = await _uow.UserInGroups.FindAsync(id);
            if (userInGroup == null)
            {
                return NotFound();
            }
            
            var vm = new UserInGroupEditViewModel()
            {
                UserSelectList = new SelectList(await _uow.BaseRepository<User>().AllAsync(), "Id", "Id", userInGroup.UserId),
                UserGroupSelectList = new SelectList(await _uow.BaseRepository<UserGroup>().AllAsync(), "Id", "Id", userInGroup.UserGroupId),
            };
            return View(vm);
        }

        // POST: UserInGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserInGroupEditViewModel vm)
        {
            if (id != vm.UserInGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.UserInGroups.Update(vm.UserInGroup);
                await _uow.SaveChangesAsync();
   
                return RedirectToAction(nameof(Index));
            }
            
            vm.UserSelectList = new SelectList(await _uow.BaseRepository<User>().AllAsync(), "Id",
                "Id", vm.UserInGroup.UserId);
            vm.UserGroupSelectList = new SelectList(await _uow.BaseRepository<UserGroup>().AllAsync(), "Id", "Id", vm.UserInGroup.UserGroupId);

            return View(vm);
        }

        // GET: UserInGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInGroup = await _uow.UserInGroups.FindAsync(id);
            if (userInGroup == null)
            {
                return NotFound();
            }

            return View(userInGroup);
        }

        // POST: UserInGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.UserInGroups.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
