using DataAccess.Repositories.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class PostulationService : IPostulationService
    {
        private readonly IPostulationRepository _postulationRepository;
        public PostulationService(IPostulationRepository postulationRepository)
        {
            _postulationRepository = postulationRepository;
        }

        public Postulation AddPostulation(Postulation postulation)
        {
            return _postulationRepository.Add(postulation);
        }

        public ICollection<Postulation> ListPostulations()
        {
            var postulations = _postulationRepository.List();

            return postulations.ToList();
        }
    }
}
