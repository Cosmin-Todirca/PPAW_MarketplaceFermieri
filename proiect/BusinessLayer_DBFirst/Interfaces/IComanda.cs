using DTOs;
using System.Collections.Generic;

namespace BusinessLayer_DBFirst.Interfaces
{
    public interface IComanda
    {
        void Add(CreateComandaDTO newComanda);
        List<ReadComandaDTO> Get();
        ReadComandaDTO Get(int Id);
        void Update(UpdateComandaDTO updatedComanda);
        void Delete(int id);
    }
}
