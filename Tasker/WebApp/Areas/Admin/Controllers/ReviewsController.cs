using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReviewsController : Controller
    {
        private readonly IAppBLL _bll;

        public ReviewsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Reviews.AllAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _bll.Reviews.FindAsync(id);

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
                ReviewGiverSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id)),
                ReviewReceiverSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                nameof(BLL.App.DTO.Identity.AppUser.Id))
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
                _bll.Reviews.Add(vm.Review);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.ReviewGiverSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                vm.Review.ReviewGiverId);
            vm.ReviewReceiverSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                vm.Review.ReviewReceiverId);

            return View(vm);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _bll.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            var vm = new ReviewEditViewModel()
            {
                ReviewGiverSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    review.ReviewGiverId),
                ReviewReceiverSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    nameof(BLL.App.DTO.Identity.AppUser.Id), 
                    review.ReviewReceiverId)
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
                _bll.Reviews.Update(vm.Review);
                await _bll.SaveChangesAsync();
  
                return RedirectToAction(nameof(Index));
            }
            vm.ReviewGiverSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                vm.Review.ReviewGiverId);
            vm.ReviewReceiverSelectList = new SelectList(await _bll.AppUsers.AllAsync(), 
                nameof(BLL.App.DTO.Identity.AppUser.Id),
                nameof(BLL.App.DTO.Identity.AppUser.Id), 
                vm.Review.ReviewReceiverId);

            return View(vm);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _bll.Reviews.FindAsync(id);
            
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
            _bll.Reviews.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
