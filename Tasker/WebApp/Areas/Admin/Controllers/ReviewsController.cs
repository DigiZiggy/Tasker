using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReviewsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public ReviewsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var reviews = await _uow.Reviews.AllAsync();

            return View(reviews);
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _uow.Reviews.FindAllIncludedAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public async Task<IActionResult> Create()
        {
            
            var vm = new ReviewCreateViewModel()
            {
                AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id", "Id")
            };
           
            return View(vm);
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.Reviews.AddAsync(vm.Review);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id",
                "Id", vm.Review.AppUserId);

            return View(vm);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _uow.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            var vm = new ReviewEditViewModel()
            {
                AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id", "Id", review.AppUserId)
            };

            return View(vm);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReviewEditViewModel vm)
        {
            if (id != vm.Review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Reviews.Update(vm.Review);
                await _uow.SaveChangesAsync();
  
                return RedirectToAction(nameof(Index));
            }
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepositoryAsync<AppUser>().AllAsync(), "Id",
                "Id", vm.Review.AppUserId);

            return View(vm);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _uow.Reviews.FindAllIncludedAsync(id);
            
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Reviews.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
