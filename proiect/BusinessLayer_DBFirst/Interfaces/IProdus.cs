using DTOs;
using System.Collections.Generic;

namespace BusinessLayer_DBFirst.Interfaces
{
    public interface IProdus
    {
        void Add(CreateProdusDTO newProdus);
        List<ReadProdusDTO> Get();
        ReadProdusDTO Get(int Id);
        void Update(UpdateProdusDTO updatedProdus);
        void Delete(int id);
        ReadProdusCuVanzatorDTO GetProdusCuVanzator(int Id);
        ReadProdusCuVanzatorDTO readProdusCuVanzatorEager(int id);
        List<ReadProdusCuVanzatorDTO> GetProduseCuVanzatori();
        void AddCuDropdown(CreateProdusCuDropdownDTO newProdus);

    }
}
