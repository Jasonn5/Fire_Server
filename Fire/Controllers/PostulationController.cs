using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Helpers;
using Services.Interfaces;
using System.Collections.Generic;

namespace Fire.Controllers
{
    [Route("api/postulation")]
    [ApiController]
    public class PostulationController : MainController
    {
        private readonly IPostulationService _postulationService;

        public PostulationController(IPostulationService postulationService)
        {
            _postulationService = postulationService;
        }

        [HttpPost]
        public ActionResult<Postulation> Post(Postulation postulation)
        {
            postulation.Date = TimeZoneHelper.GetSaWesternStandardTime();
            var response = _postulationService.AddPostulation(postulation);

            return Ok(response);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<ICollection<Postulation>> List()
        {
            return Ok(_postulationService.ListPostulations());
        }
    }
}
