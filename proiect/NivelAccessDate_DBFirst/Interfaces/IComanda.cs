using System.Collections.Generic;
using ViewModels;

namespace NivelAccessDate_DBFirst.Interfaces
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
