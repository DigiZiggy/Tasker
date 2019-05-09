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
    public class UserOnAddressesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public UserOnAddressesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: UserOnAddresses
        public async Task<IActionResult> Index()
        {
            var userOnAddresses = await _uow.UserOnAddresses.AllAsync();

            return View(userOnAddresses);
        }

        // GET: UserOnAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnAddress = await _uow.UserOnAddresses.FindAllIncludedAsync(id);

            if (userOnAddress == null)
            {
                return NotFound();
            }

            return View(userOnAddress);
        }

        // GET: UserOnAddresses/Create
        public async Task<IActionResult> Create()
        {
            
            var vm = new UserOnAddressCreateViewModel()
            {
                AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id", "Id"),
                AddressSelectList = new SelectList(await _uow.BaseRepositoryAsync<Address>().AllAsync(), "Id", "Id"),
            };
            
            return View(vm);
        }


        // POST: UserOnAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserOnAddressCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.UserOnAddresses.AddAsync(vm.UserOnAddress);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id",
                "Id", vm.UserOnAddress.AppUserId);
            vm.AddressSelectList = new SelectList(await _uow.BaseRepositoryAsync<Address>().AllAsync(), "Id", "Id", vm.UserOnAddress.AddressId);

            return View(vm);

        }

        // GET: UserOnAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnAddress = await _uow.UserOnAddresses.FindAsync(id);
            if (userOnAddress == null)
            {
                return NotFound();
            }
            var vm = new UserOnAddressEditViewModel()
            {
                AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id", "Id", userOnAddress.AppUserId),
                AddressSelectList = new SelectList(await _uow.BaseRepositoryAsync<Address>().AllAsync(), "Id", "Id", userOnAddress.AddressId),
            };
            
            return View(vm);
        }

        // POST: UserOnAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserOnAddressEditViewModel vm)
        {
            if (id != vm.UserOnAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.UserOnAddresses.Update(vm.UserOnAddress);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id",
                "Id", vm.UserOnAddress.AppUserId);
            vm.AddressSelectList = new SelectList(await _uow.BaseRepositoryAsync<Address>().AllAsync(), "Id", "Id", vm.UserOnAddress.AddressId);

            return View(vm);

        }

        // GET: UserOnAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnAddress = await _uow.UserOnAddresses.FindAllIncludedAsync(id);

            if (userOnAddress == null)
            {
                return NotFound();
            }
            return View(userOnAddress);
        }

        // POST: UserOnAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.UserOnAddresses.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
