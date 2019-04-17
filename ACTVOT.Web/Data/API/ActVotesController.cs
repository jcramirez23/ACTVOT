
namespace ACTVOT.Web.Data.API
{
    using Data;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[Controller]")]
    public class ActVotesController : Controller
    {
        private readonly IActVoteRepository actVoteRepository;

        public ActVotesController(IActVoteRepository actVoteRepository)
        {
            this.actVoteRepository = actVoteRepository;
        }
        [HttpGet]
        public IActionResult GetActvotes()
        {
            return Ok(this.actVoteRepository.GetAll());  

        }
    }
} 
