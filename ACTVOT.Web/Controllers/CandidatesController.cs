using ACTVOT.Web.Data;
using ACTVOT.Web.Data.Entities;
using ACTVOT.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            return View(this.candidatesRepository.GetAll().OrderBy(p => p.name));
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await this.candidatesRepository.GetByIdAsync(id.Value);
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
        public async Task<IActionResult> Create(CandidatesViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Candidate",
                       file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Candidate/{file}";
                }
                var candidates  = this.ToActvote(view, path);
                await this.candidatesRepository.CreateAsync(candidates);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Candidates ToActvote(CandidatesViewModel view, string path)
        {
            return new Candidates
            {
                Id=view.Id,
                ImageUrl=path,
                name=view.name,
                LastName=view.LastName,
                Polparty=view.Polparty
            };
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await this.candidatesRepository.GetByIdAsync(id.Value);
            if (candidates == null)
            {
                return NotFound();
            }
            var view = this.ToCandidateViewModel(candidates);
            return View(view);
        }

        private CandidatesViewModel ToCandidateViewModel(Candidates candidates)
        {
            return new CandidatesViewModel
            {

                Id = candidates.Id,
                ImageUrl = candidates.ImageUrl,
                name = candidates.name,
                LastName = candidates.LastName,
                Polparty = candidates.Polparty
            };
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CandidatesViewModel view)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";

                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Candidate",
                           file);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Candidate/{file}";
                    }
                    var candidates = this.ToActvote(view, path);

                    await this.candidatesRepository.UpdateAsync(candidates);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.candidatesRepository.ExistAsync(view.Id))
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
            return View(view);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await this.candidatesRepository.GetByIdAsync(id.Value);
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
            var candidates = await this.candidatesRepository.GetByIdAsync(id);
            await this.candidatesRepository.DeleteAsync(candidates);
            return RedirectToAction(nameof(Index));
        }

    }
}
