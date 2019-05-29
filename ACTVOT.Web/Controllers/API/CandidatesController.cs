
namespace ACTVOT.Web.Controllers.API
{
    using ACTVOT.Web.Data;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/[Controller]")]
   
    public class CandidatesController : Controller
    {
        private readonly ICandidatesRepository candidatesRepository;

        public CandidatesController(ICandidatesRepository candidatesRepository)
        {
            this.candidatesRepository = candidatesRepository;
        }

        [HttpGet]
        public IActionResult GetCandidates()
        {
            return Ok(this.candidatesRepository.GetAll());
        }
    }


}
