using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IdentificationsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public IdentificationsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Identifications
        public async Task<IActionResult> Index()
        {
            var identifications = await _uow.Identifications.AllAsync();
            return View(identifications);
        }

        // GET: Identifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identification = await _uow.Identifications.FindAllIncludedAsync(id);

            if (identification == null)
            {
                return NotFound();
            }

            return View(identification);
        }

        // GET: Identifications/Create
        public async Task<IActionResult> Create()
        {
            var vm = new IdentificationCreateViewModel()
            {
                AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), nameof(AppUser.Id), nameof(AppUser.Id))
            };
            
            return View(vm);
        }

        // POST: Identifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentificationCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.Identifications.AddAsync(vm.Identification);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id",
                "Id", vm.Identification.AppUserId);
      
            return View(vm);
        }

        // GET: Identifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identification = await _uow.Identifications.FindAsync(id);
            if (identification == null)
            {
                return NotFound();
            }
            var vm = new IdentificationEditViewModel()
            {
                AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id", "Id", identification.AppUserId),
            };
           
            return View(vm);

        }

        // POST: Identifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IdentificationEditViewModel vm)
        {
            if (id != vm.Identification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Identifications.Update(vm.Identification);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id",
                "Id", vm.Identification.AppUserId);
        
            return View(vm);
        }

        // GET: Identifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identification = await _uow.Identifications.FindAllIncludedAsync(id);

            if (identification == null)
            {
                return NotFound();
            }

            return View(identification);
        }

        // POST: Identifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Identifications.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
