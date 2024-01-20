using DTOs;
using System.Collections.Generic;

namespace BusinessLayer_DBFirst.Interfaces
{
    public interface IVanzator
    {
        void Add(CreateVanzatorDTO newVanzator);
        List<ReadVanzatorDTO> Get();
        ReadVanzatorDTO Get(int Id);
        ReadVanzatorCardDTO GetCard(int Id);
        List<ReadVanzatorCardDTO> GetAllCard();
        void Update(UpdateVanzatorDTO updatedVanzator);
        void Delete(int id);
        void LogicalDelete(int id);

        List<ReadVanzatorDTO> GetAll();



    }
}
