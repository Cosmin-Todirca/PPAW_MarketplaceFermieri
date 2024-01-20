using DTOs;
using System.Collections.Generic;

namespace BusinessLayer_DBFirst.Interfaces
{
    public interface IComanda
    {
        void Add(CreateComandaViewModel newComanda);
        List<ReadComandaViewModel> Get();
        ReadComandaViewModel Get(int Id);
        void Update(UpdateComandaViewModel updatedComanda);
        void Delete(int id);
    }
}
