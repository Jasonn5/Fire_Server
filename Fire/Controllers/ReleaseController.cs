using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Helpers;
using Services.Interfaces;
using System.Collections.Generic;

namespace Fire.Controllers
{
    [Route("api/release")]
    [ApiController]
    public class ReleaseController : MainController
    {
        private readonly IReleaseService _releaseService;

        public ReleaseController(IReleaseService releaseService)
        {
            _releaseService = releaseService;
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public ActionResult<Release> Post(Release release)
        {
            release.Date = TimeZoneHelper.GetSaWesternStandardTime();
            var response = _releaseService.AddRelease(release);

            return Ok(response);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<ICollection<Release>> List()
        {
            return Ok(_releaseService.List());
        }
    }
}
