namespace ACTVOT.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using ACTVOT.Web.Models;
    using Data;
    using Data.Entities;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class ActVotesController : Controller
    {
        private readonly IActVoteRepository actVoteRepository;
        private readonly IUserHelper userHelper;

        public ActVotesController(IActVoteRepository actVoteRepository, IUserHelper userHelper)
        {
            this.actVoteRepository = actVoteRepository;
            this.userHelper = userHelper;
        }

        // GET: ActVotes
        public IActionResult Index()
        {
            return View(this.actVoteRepository.GetAll().OrderBy(p=>p.Name));
        }

        // GET: ActVotes/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create(ActVoteViewModel view)
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
                        "wwwroot\\images\\Actvot",
                       file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Actvot/{file}";
                }
                var Actvote = this.ToActvote(view, path);
                //TODO:Change for the logged user
                Actvote.user = await this.userHelper.GetUserByEmailAsync("jcamilor.454@gmail.com");
                await this.actVoteRepository.CreateAsync(Actvote);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private ActVote ToActvote(ActVoteViewModel view, string path)
        {
            return new ActVote
            {
                Id = view.Id,
                ImageUrl = path,
                Name = view.Name,
                Actstar = view.Actstar,
                Endstar = view.Endstar,
                Description = view.Description,
                user = view.user

            };

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
            var view = this.ToActvoteViewModel(actVote);
            return View(view);
        }

        private ActVoteViewModel ToActvoteViewModel(ActVote actVote)
        {
            return new ActVoteViewModel
            {
                Id = actVote.Id,
                Name = actVote.Name,
                Actstar = actVote.Actstar,
                Endstar = actVote.Endstar,
                ImageUrl = actVote.ImageUrl,
                Description = actVote.Description,
                user = actVote.user
            };

        }



        // POST: ActVotes1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ActVoteViewModel view)
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
                            "wwwroot\\images\\Actvot",
                           file);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Actvot/{file}";
                    }
                    var Actvote = this.ToActvote(view, path);

                    //TODO:Change for the logged user
                    Actvote.user = await this.userHelper.GetUserByEmailAsync("jcamilor.454@gmail.com");
                    await this.actVoteRepository.UpdateAsync(Actvote);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.actVoteRepository.ExistAsync(view.Id))
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