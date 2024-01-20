using DTOs;
using System.Collections.Generic;

namespace BusinessLayer_DBFirst.Interfaces
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
