using Entities;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IReleaseRepository
    {
        Release Add(Release release);
        Release Delete(Release release);
        IEnumerable<Release> List();
        Release GetReleaseById(int id);

    }
}
