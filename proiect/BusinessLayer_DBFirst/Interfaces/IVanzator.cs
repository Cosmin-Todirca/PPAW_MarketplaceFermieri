using DTOs;
using System.Collections.Generic;

namespace BusinessLayer_DBFirst.Interfaces
{
    public interface IVanzator
    {
        void Add(CreateVanzatorViewModel newVanzator);
        List<ReadVanzatorViewModel> Get();
        ReadVanzatorViewModel Get(int Id);
        ReadVanzatorCardViewModel GetCard(int Id);
        List<ReadVanzatorCardViewModel> GetAllCard();
        void Update(UpdateVanzatorViewModel updatedVanzator);
        void Delete(int id);
        void LogicalDelete(int id);

        List<ReadVanzatorViewModel> GetAll();



    }
}
