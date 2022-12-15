using DataAccess.Repositories.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class FireReportRepository : IFireReportRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public FireReportRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public FireReport Add(FireReport fireReport)
        {
            _dataAccess.Set<FireReport>().Add(fireReport);
            _dataAccess.SaveChanges();

            return fireReport;
        }

        public IEnumerable<FireReport> List()
        {
            var fireReports = _dataAccess.Set<FireReport>().FromSqlRaw($"dbo.GetFireReports").AsEnumerable();

            return fireReports;
        }
    }
}
