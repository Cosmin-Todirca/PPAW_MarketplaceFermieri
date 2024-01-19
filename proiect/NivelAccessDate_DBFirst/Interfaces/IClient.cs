using System.Collections.Generic;
using ViewModels;

namespace NivelAccessDate_DBFirst.Interfaces
{
    public interface IClient
    {
        void Add(CreateClientViewModel newClient);
        List<ReadClientViewModel> Get();
        ReadClientViewModel Get(int Id);
        void Update(UpdateClientViewModel updatedClient);
        void Delete(int id);
    }
}
