using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentsController : Controller
    {
        private readonly IAppBLL _bll;

        public PaymentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Payments.AllAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _bll.Payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public async Task<IActionResult> Create()
        {
            var vm = new PaymentCreateViewModel()
            {
                InvoiceSelectList = new SelectList(await _bll.Invoices.AllAsync(), 
                    nameof(BLL.App.DTO.Invoice.Id), 
                    nameof(BLL.App.DTO.Invoice.Id)),

            };

            return View(vm);
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.Payments.Add(vm.Payment);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.InvoiceSelectList = new SelectList(await _bll.Invoices.AllAsync(), 
                nameof(BLL.App.DTO.Invoice.Id),
                nameof(BLL.App.DTO.Invoice.Id), 
                vm.Payment.InvoiceId);

            return View(vm);

        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _bll.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            var vm = new PaymentEditViewModel()
            {
                InvoiceSelectList = new SelectList(await _bll.Invoices.AllAsync(), 
                    nameof(BLL.App.DTO.Invoice.Id), 
                    nameof(BLL.App.DTO.Invoice.Id), 
                    payment.InvoiceId),

            };

            return View(vm);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PaymentEditViewModel vm)
        {
            if (id != vm.Payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Payments.Update(vm.Payment);
                await _bll.SaveChangesAsync();
      
                return RedirectToAction(nameof(Index));
            }
                 
            vm.InvoiceSelectList = new SelectList(await _bll.Invoices.AllAsync(), 
                nameof(BLL.App.DTO.Invoice.Id),
                nameof(BLL.App.DTO.Invoice.Id), 
                vm.Payment.InvoiceId);
            
            return View(vm);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _bll.Payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.Payments.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
