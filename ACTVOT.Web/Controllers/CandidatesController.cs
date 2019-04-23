using ACTVOT.Web.Data;
using ACTVOT.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Create(Candidates candidates)
        {
            if (ModelState.IsValid)
            {

                await this.candidatesRepository.CreateAsync(candidates);
                return RedirectToAction(nameof(Index));
            }
            return View(candidates);
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

                    await this.candidatesRepository.UpdateAsync(candidates);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.candidatesRepository.ExistAsync(candidates.Id))
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
