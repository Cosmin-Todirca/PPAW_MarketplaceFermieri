using System.Collections.Generic;
using ViewModels;

namespace NivelAccessDate_DBFirst.Interfaces
{
    public interface IProdus
    {
        void Add(CreateProdusViewModel newProdus);
        List<ReadProdusViewModel> Get();
        ReadProdusViewModel Get(int Id);
        void Update(UpdateProdusViewModel updatedProdus);
        void Delete(int id);
        ReadProdusCuVanzatorViewModel GetProdusCuVanzator(int Id);
        ReadProdusCuVanzatorViewModel readProdusCuVanzatorEager(int id);
        List<ReadProdusCuVanzatorViewModel> GetProduseCuVanzatori();
        void AddCuDropdown(CreateProdusViewModelCuDropdown newProdus);

    }
}
