using Entities;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IPostulationRepository
    {
        Postulation Add(Postulation postulation);

        IEnumerable<Postulation> List();
    }
}
