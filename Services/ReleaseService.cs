using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ReleaseService : IReleaseService
    {
        private readonly IReleaseRepository _releaseRepository;
        public ReleaseService(IReleaseRepository releaseRepository)
        {
            _releaseRepository = releaseRepository;
        }

        public Release AddRelease(Release release)
        {
            return _releaseRepository.Add(release);
        }

        public ICollection<Release> List()
        {
            var releases = _releaseRepository.List();

            return releases.ToList();
        }
    }
}
