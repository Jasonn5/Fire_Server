using DataAccess.Repositories.Interfaces;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class FireReportService : IFireReportService
    {
        private readonly IFireReportRepository _fireReportRepository;
        public FireReportService(IFireReportRepository fireReportRepository)
        {
            _fireReportRepository = fireReportRepository;
        }

        public FireReport AddFireReport(FireReport fireReport)
        {
            return _fireReportRepository.Add(fireReport);
        }

        public FireReport GetFireReportById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<FireReport> ListFireReports()
        {
            var fireReports = _fireReportRepository.List();

            return fireReports.ToList();
        }
    }
}
