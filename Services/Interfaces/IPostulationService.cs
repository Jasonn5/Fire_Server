using Entities;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IPostulationService
    {
        public Postulation AddPostulation(Postulation postulation);
        public ICollection<Postulation> ListPostulations();
    }
}
