
namespace ACTVOT.Web.Controllers
{
    using System.Threading.Tasks;
    using Data;
    using Data.Entities;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class ActVotes1Controller : Controller
    {
        private readonly IActVoteRepository actVoteRepository;
        private readonly IUserHelper userHelper;

        public ActVotes1Controller(IActVoteRepository actVoteRepository,IUserHelper userHelper)
        {
            this.actVoteRepository = actVoteRepository;
            this.userHelper = userHelper;
        }

        // GET: ActVotes
        public IActionResult Index()
        {
            return View(this.actVoteRepository.GetAll());
        }
        
        // GET: ActVotes/Details/5
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actVote = await this.actVoteRepository.GetByIdAsync(id.Value);
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
                //TODO:Change for the logged user
                actVote.user = await this.userHelper.GetUserByEmailAsync("jcamilor.454@gmail.com");
                await this.actVoteRepository.CreateAsync(actVote);
                return RedirectToAction(nameof(Index));
            }
            return View(actVote);
        }

        // GET: ActVotes1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actVote = await this.actVoteRepository.GetByIdAsync(id.Value);
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
                    //TODO:Change for the logged user
                    actVote.user = await this.userHelper.GetUserByEmailAsync("jcamilor.454@gmail.com");
                    await this.actVoteRepository.UpdateAsync(actVote);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.actVoteRepository.ExistAsync(actVote.Id))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           var actVote = await this.actVoteRepository.GetByIdAsync(id.Value);

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
            var actVote = await this.actVoteRepository.GetByIdAsync(id);
            await this.actVoteRepository.DeleteAsync(actVote);
            return RedirectToAction(nameof(Index));
        }
    }
}
