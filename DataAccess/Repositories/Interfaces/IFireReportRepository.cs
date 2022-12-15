using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface IFireReportRepository
    {
        FireReport Add(FireReport fireReport);

        IEnumerable<FireReport> List();
    }
}
