﻿using System;
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
    public class CandidatesController : Controller
    {
        
        private readonly ICandidatesRepository candidatesRepository;

        public CandidatesController(ICandidatesRepository candidatesRepository)
        {
            this.candidatesRepository = candidatesRepository;
        }

        // GET: Candidates
        public IActionResult Index()
        {
            return View(this.candidatesRepository.GetCandidat());
        }

        // GET: Candidates/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = this.candidatesRepository.GetCandidat(id.Value);
            if (candidates == null)
            {
                return NotFound();
            }

            return View(candidates);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Candidates candidates)
        {
            if (ModelState.IsValid)
            {
                this.candidatesRepository.AddCandidat(candidates);
                await this.candidatesRepository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidates);
        }

        // GET: Candidates/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = this.candidatesRepository.GetCandidat(id.Value);
            if (candidates == null)
            {
                return NotFound();
            }
            return View(candidates);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Candidates candidates)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    this.candidatesRepository.UpdateCandidat(candidates);
                    await this.candidatesRepository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.candidatesRepository.CandidatExists(candidates.Id))
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
            return View(candidates);
        }

        // GET: Candidates/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = this.candidatesRepository.GetCandidat(id.Value );
            if (candidates == null)
            {
                return NotFound();
            }

            return View(candidates);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidates = this.candidatesRepository.GetCandidat(id);
            this.candidatesRepository.RemoveCandidat(candidates);
            await this.candidatesRepository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
