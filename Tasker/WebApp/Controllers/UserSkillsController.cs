using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class UserSkillsController : Controller
    {
        private readonly AppDbContext _context;

        public UserSkillsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserSkills
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UserSkills.Include(u => u.Skill).Include(u => u.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: UserSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSkill = await _context.UserSkills
                .Include(u => u.Skill)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSkill == null)
            {
                return NotFound();
            }

            return View(userSkill);
        }

        // GET: UserSkills/Create
        public IActionResult Create()
        {
            ViewData["SkillId"] = new SelectList(_context.Skills, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: UserSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Start,End,Comment,UserId,SkillId,Id")] UserSkill userSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SkillId"] = new SelectList(_context.Skills, "Id", "Name", userSkill.SkillId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userSkill.UserId);
            return View(userSkill);
        }

        // GET: UserSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSkill = await _context.UserSkills.FindAsync(id);
            if (userSkill == null)
            {
                return NotFound();
            }
            ViewData["SkillId"] = new SelectList(_context.Skills, "Id", "Name", userSkill.SkillId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userSkill.UserId);
            return View(userSkill);
        }

        // POST: UserSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Start,End,Comment,UserId,SkillId,Id")] UserSkill userSkill)
        {
            if (id != userSkill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSkillExists(userSkill.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SkillId"] = new SelectList(_context.Skills, "Id", "Name", userSkill.SkillId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", userSkill.UserId);
            return View(userSkill);
        }

        // GET: UserSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSkill = await _context.UserSkills
                .Include(u => u.Skill)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSkill == null)
            {
                return NotFound();
            }

            return View(userSkill);
        }

        // POST: UserSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userSkill = await _context.UserSkills.FindAsync(id);
            _context.UserSkills.Remove(userSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserSkillExists(int id)
        {
            return _context.UserSkills.Any(e => e.Id == id);
        }
    }
}
