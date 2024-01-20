using DTOs;
using System.Collections.Generic;

namespace BusinessLayer_DBFirst.Interfaces
{
    public interface IObiectComanda
    {
        void Add(CreateObiectComandaViewModel newObiectComanda);
        List<ReadObiectComandaViewModel> Get();
        ReadObiectComandaViewModel Get(int Id);
        void Update(UpdateObiectComandaViewModel updatedObiectComanda);
        void Delete(int id);
    }
}
