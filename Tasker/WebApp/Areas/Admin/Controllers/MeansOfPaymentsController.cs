using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MeansOfPaymentsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public MeansOfPaymentsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: MeansOfPayments
        public async Task<IActionResult> Index()
        {
            var meansOfPayment = await _uow.MeansOfPayments.AllAsync();

            return View(meansOfPayment);
        }

        // GET: MeansOfPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meansOfPayment = await _uow.MeansOfPayments.FindAsync(id);

            if (meansOfPayment == null)
            {
                return NotFound();
            }

            return View(meansOfPayment);
        }

        // GET: MeansOfPayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeansOfPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Comment,Id")] MeansOfPayment meansOfPayment)
        {
            if (ModelState.IsValid)
            {
                await _uow.MeansOfPayments.AddAsync(meansOfPayment);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meansOfPayment);
        }

        // GET: MeansOfPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meansOfPayment = await _uow.MeansOfPayments.FindAsync(id);
            if (meansOfPayment == null)
            {
                return NotFound();
            }
            return View(meansOfPayment);
        }

        // POST: MeansOfPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Comment,Id")] MeansOfPayment meansOfPayment)
        {
            if (id != meansOfPayment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.MeansOfPayments.Update(meansOfPayment);
                await _uow.SaveChangesAsync();
                    
                return RedirectToAction(nameof(Index));
            }
            return View(meansOfPayment);
        }

        // GET: MeansOfPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meansOfPayment = await _uow.MeansOfPayments.FindAsync(id);
            if (meansOfPayment == null)
            {
                return NotFound();
            }

            return View(meansOfPayment);
        }

        // POST: MeansOfPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.MeansOfPayments.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
