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
    public class PostulationRepository : IPostulationRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public PostulationRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        } 

        public Postulation Add(Postulation postulation)
        {
            _dataAccess.Set<Postulation>().Add(postulation);
            _dataAccess.SaveChanges();

            return postulation;
        }

        public IEnumerable<Postulation> List()
        {
            var postulations = _dataAccess.Set<Postulation>();

            return postulations;
        }
    }
}
