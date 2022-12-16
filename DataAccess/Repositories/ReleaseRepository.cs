using DataAccess.Repositories.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class ReleaseRepository : IReleaseRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public ReleaseRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Release Add(Release release)
        {
            _dataAccess.Set<Release>().Add(release);
            _dataAccess.SaveChanges();

            return release;
        }

        public Release Delete(Release release)
        {
            throw new NotImplementedException();
        }

        public Release GetReleaseById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Release> List()
        {
            var releases = _dataAccess.Set<Release>();

            return releases;
        }
    }
}
