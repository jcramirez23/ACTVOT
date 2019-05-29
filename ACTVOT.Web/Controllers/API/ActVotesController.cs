

namespace ACTVOT.Web.Data.API
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using ACTVOT.Web.Helpers;
    using ACTVOT.Web.Data;

    [Route("api/[Controller]")]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]


    public class ActVotesController : Controller
    {
        private readonly ICandidatesRepository candidateRepository;
        private readonly IActVoteRepository actVoteRepository;
        private readonly IUserHelper userHelper;
        private readonly DataContext context;

        public ActVotesController(IActVoteRepository actVoteRepository,
            ICandidatesRepository candidatesRepository,
            IUserHelper userHelper)
        {
            this.actVoteRepository = actVoteRepository;
            this.CandidatesRepository = candidatesRepository;
            this.userHelper = userHelper;
        }

        public ICandidatesRepository CandidatesRepository { get; }

        [HttpGet]
        public IActionResult GetEvents()
        {
            return this.Ok(this.actVoteRepository.GetAllWithUsers());
        }





    }
}
