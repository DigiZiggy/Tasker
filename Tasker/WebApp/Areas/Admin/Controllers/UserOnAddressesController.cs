using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserOnAddressesController : Controller
    {
        private readonly IAppBLL _bll;

        public UserOnAddressesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: UserOnAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _bll.UserOnAddresses.AllAsync());
        }

        // GET: UserOnAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnAddress = await _bll.UserOnAddresses.FindAsync(id);

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
                AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id)),
                AddressSelectList = new SelectList(await _bll.Addresses.AllAsync(), 
                    nameof(BLL.App.DTO.Address.Id), 
                    nameof(BLL.App.DTO.Address.Id)),
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
                await _bll.UserOnAddresses.AddAsync(vm.UserOnAddress);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                vm.UserOnAddress.AppUserId);
            vm.AddressSelectList = new SelectList(await _bll.Addresses.AllAsync(), 
                nameof(BLL.App.DTO.Address.Id), 
                nameof(BLL.App.DTO.Address.Id), 
                vm.UserOnAddress.AddressId);

            return View(vm);

        }

        // GET: UserOnAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnAddress = await _bll.UserOnAddresses.FindAsync(id);
            if (userOnAddress == null)
            {
                return NotFound();
            }
            var vm = new UserOnAddressEditViewModel();
            vm.UserOnAddress = userOnAddress;
            vm.AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    userOnAddress.AppUserId);
            vm.AddressSelectList = new SelectList(await _bll.Addresses.AllAsync(), 
                    nameof(BLL.App.DTO.Address.Id), 
                    nameof(BLL.App.DTO.Address.Id), 
                    userOnAddress.AddressId);
            
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
                _bll.UserOnAddresses.Update(vm.UserOnAddress);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                vm.UserOnAddress.AppUserId);
            vm.AddressSelectList = new SelectList(await _bll.Addresses.AllAsync(), 
                nameof(BLL.App.DTO.Address.Id), 
                nameof(BLL.App.DTO.Address.Id), 
                vm.UserOnAddress.AddressId);

            return View(vm);

        }

        // GET: UserOnAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOnAddress = await _bll.UserOnAddresses.FindAsync(id);

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
            _bll.UserOnAddresses.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
