using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IFireReportService
    {
        public FireReport AddFireReport(FireReport fireReport);
        public FireReport GetFireReportById(int id);
        public ICollection<FireReport> ListFireReports();
    }
}
