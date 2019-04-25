using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HourlyRatesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public HourlyRatesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: HourlyRates
        public async Task<IActionResult> Index()
        {
            var hourlyRates = await _uow.HourlyRates.AllAsync();

            return View(hourlyRates);
        }

        // GET: HourlyRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourlyRate = await _uow.HourlyRates.FindAsync(id);

            if (hourlyRate == null)
            {
                return NotFound();
            }

            return View(hourlyRate);
        }

        // GET: HourlyRates/Create
        public async Task<IActionResult> Create()
        {
            var vm = new HourlyRateCreateViewModel()
            {
                PriceListSelectList = new SelectList(await _uow.BaseRepositoryAsync<PriceList>().AllAsync(), "Id", "Id"),
            };

            return View(vm);
        }

        // POST: HourlyRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HourlyRateCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.HourlyRates.AddAsync(vm.HourlyRate);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.PriceListSelectList = new SelectList(await _uow.BaseRepositoryAsync<PriceList>().AllAsync(), "Id", "Id", vm.HourlyRate.PriceListId);

            return View(vm);
        }

        // GET: HourlyRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourlyRate = await _uow.HourlyRates.FindAsync(id);
            if (hourlyRate == null)
            {
                return NotFound();
            }
            
            var vm = new HourlyRateEditViewModel()
            {
                PriceListSelectList = new SelectList(await _uow.BaseRepositoryAsync<PriceList>().AllAsync(), "Id", "Id", hourlyRate.PriceListId),
            };
            
            return View(vm);
        }

        // POST: HourlyRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HourlyRateEditViewModel vm)
        {
            if (id != vm.HourlyRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.HourlyRates.Update(vm.HourlyRate);
                await _uow.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            vm.PriceListSelectList = new SelectList(await _uow.BaseRepositoryAsync<PriceList>().AllAsync(), "Id", "Id", vm.HourlyRate.PriceListId);

            return View(vm);
        }

        // GET: HourlyRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hourlyRate = await _uow.HourlyRates.FindAsync(id);
            if (hourlyRate == null)
            {
                return NotFound();
            }

            return View(hourlyRate);
        }

        // POST: HourlyRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.HourlyRates.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
