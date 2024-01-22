using DTOs;
using System.Collections.Generic;

namespace BusinessLayer_DBFirst.Interfaces
{
    public interface IObiectComanda
    {
        void Add(CreateObiectComandaDTO newObiectComanda);
        void AddToCart(CreateObiectComandaDTO newObiectComanda);

        List<ReadObiectComandaDTO> Get();
        ReadObiectComandaDTO Get(int Id);
        ReadObiectComandaCartDTO Get(int idComanda, int idClient);

        void Update(UpdateObiectComandaDTO updatedObiectComanda);
        void Delete(int id);
    }
}
