using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ACTVOT.Web.Data;
using ACTVOT.Web.Data.Entities;

namespace ACTVOT.Web.Views
{
    public class ActVotesController : Controller
    {
        private readonly DataContext _context;

        public ActVotesController(DataContext context)
        {
            _context = context;
        }

        // GET: ActVotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActVotes.ToListAsync());
        }

        // GET: ActVotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actVote = await _context.ActVotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actVote == null)
            {
                return NotFound();
            }

            return View(actVote);
        }

        // GET: ActVotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActVotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Actstar,Endstar,ImageUrl,Description")] ActVote actVote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actVote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actVote);
        }

        // GET: ActVotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actVote = await _context.ActVotes.FindAsync(id);
            if (actVote == null)
            {
                return NotFound();
            }
            return View(actVote);
        }

        // POST: ActVotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Actstar,Endstar,ImageUrl,Description")] ActVote actVote)
        {
            if (id != actVote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actVote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActVoteExists(actVote.Id))
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
            return View(actVote);
        }

        // GET: ActVotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actVote = await _context.ActVotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actVote == null)
            {
                return NotFound();
            }

            return View(actVote);
        }

        // POST: ActVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actVote = await _context.ActVotes.FindAsync(id);
            _context.ActVotes.Remove(actVote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActVoteExists(int id)
        {
            return _context.ActVotes.Any(e => e.Id == id);
        }
    }
}
