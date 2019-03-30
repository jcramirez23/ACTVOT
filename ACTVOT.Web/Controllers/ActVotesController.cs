using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ACTVOT.Web.Data;
using ACTVOT.Web.Data.Entities;

namespace ACTVOT.Web.Controllers
{
    public class ActVotes1Controller : Controller
    {
        private readonly IRepository repository;

        public ActVotes1Controller(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: ActVotes
        public IActionResult Index()
        {
            return View(this.repository.GetActVotes());
        }
        
        // GET: ActVotes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actVote = this.repository.GetActVote(id.Value);
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

        // POST: ActVotes1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ActVote actVote)
        {
            if (ModelState.IsValid)
            {
                this.repository.AddActVote(actVote);
                await this.repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actVote);
        }

        // GET: ActVotes1/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actVote = this.repository.GetActVote(id.Value);
            if (actVote == null)
            {
                return NotFound();
            }
            return View(actVote);
        }

        // POST: ActVotes1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ActVote actVote)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.UpdateActVote(actVote);
                    await this.repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.ActVoteExists(actVote.Id))
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

        // GET: ActVotes1/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           var actVote = this.repository.GetActVote(id.Value);
           
            if (actVote == null)
            {
                return NotFound();
            }

            return View(actVote);
        }

        // POST: ActVotes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actVote = this.repository.GetActVote(id);
            this.repository.RemoveActVote(actVote);
            await this.repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
