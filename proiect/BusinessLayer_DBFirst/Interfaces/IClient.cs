using DTOs;
using System.Collections.Generic;

namespace BusinessLayer_DBFirst.Interfaces
{
    public interface IClient
    {
        void Add(CreateClientDTO newClient);
        List<ReadClientDTO> Get();
        ReadClientDTO Get(int Id);
        void Update(UpdateClientDTO updatedClient);
        void Delete(int id);
    }
}
