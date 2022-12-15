using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fire.Controllers
{
    [Route("api/fire-report")]
    [ApiController]
    public class FireReportController : MainController
    {
        private readonly IFireReportService _fireReportService;

        public FireReportController(IFireReportService fireReportService)
        {
            _fireReportService = fireReportService;
        }

        [HttpPost]
        public ActionResult<FireReport> Post(FireReport fireReport)
        {
            fireReport.Date = TimeZoneHelper.GetSaWesternStandardTime();
            var response = _fireReportService.AddFireReport(fireReport);

            return Ok(response);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<ICollection<FireReport>> ListFireReports()
        { 
            return Ok(_fireReportService.ListFireReports());
        }

        [HttpGet("{id}")]
        public ActionResult<FireReport> GetById(int id)
        {
            var fireReport = _fireReportService.GetFireReportById(id);
            return Ok(fireReport);
        }
    }
}
