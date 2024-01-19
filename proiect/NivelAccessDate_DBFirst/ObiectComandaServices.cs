//using Repository_CodeFirst;
using Accesor;
using Exceptions;
using NivelAccessDate_DBFirst.Interfaces;
using Repository_DBFirst;
using System.Collections.Generic;
using ViewModels;

namespace BusinessLayer_DBFirst
{
    public class ObiectComandaServices : IObiectComanda
    {
        private marketplace_fermieriEntities _db;
        private ObiecteComandaAccesor _ObiecteComandaServices;

        public ObiectComandaServices()
        {
            //_db = new marketplace_fermieriEntities();
            //_ObiecteComandaServices = new ObiecteComandaAccesor(_db);
        }

        public ObiectComandaServices(IDBContext db)
        {
            _db = (marketplace_fermieriEntities)db;
            _ObiecteComandaServices = new ObiecteComandaAccesor(_db);
        }

        public void Add(CreateObiectComandaViewModel newObiectComanda)
        {
            obiecteComanda obiectComanda = new obiecteComanda()
            {
                idComanda = newObiectComanda.idComanda,
                idProdus = newObiectComanda.idProdus,
                idClient = newObiectComanda.idClient,
                situatiePlata = newObiectComanda.situatiePlata,
                cantitateComanda = newObiectComanda.cantitateComanda
            };

            _ObiecteComandaServices.Add(obiectComanda);
        }

        public List<ReadObiectComandaViewModel> Get()
        {
            List<obiecteComanda> bctCmnda = (List<obiecteComanda>)_ObiecteComandaServices.GetAll();

            if (bctCmnda == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            List<ReadObiectComandaViewModel> readObiecteComanda = new List<ReadObiectComandaViewModel>();
            foreach (obiecteComanda bctCmnd in bctCmnda) //not such a great implement, but enough for the moment
            {
                readObiecteComanda.Add(new ReadObiectComandaViewModel()
                {
                    idObiectComanda = bctCmnd.idObiectComanda,
                    idComanda = bctCmnd.idComanda,
                    idProdus = bctCmnd.idProdus,
                    idClient = bctCmnd.idClient,
                    situatiePlata = bctCmnd.situatiePlata,
                    cantitateComanda = bctCmnd.cantitateComanda
                });
            }
            return readObiecteComanda;
        }

        public ReadObiectComandaViewModel Get(int Id)
        {
            obiecteComanda obiectComanda = _ObiecteComandaServices.Get(Id);

            if (obiectComanda == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            ReadObiectComandaViewModel readObiectComandaViewModel = new ReadObiectComandaViewModel()
            {
                idObiectComanda = obiectComanda.idObiectComanda,
                idComanda = obiectComanda.idComanda,
                idProdus = obiectComanda.idProdus,
                idClient = obiectComanda.idClient,
                situatiePlata = obiectComanda.situatiePlata,
                cantitateComanda = obiectComanda.cantitateComanda
            };
            return readObiectComandaViewModel;
        }
        public void Update(UpdateObiectComandaViewModel updatedObiectComanda)
        {
            obiecteComanda obiectComandaToBeUpdated = _ObiecteComandaServices.Get(updatedObiectComanda.idClient);

            if (obiectComandaToBeUpdated == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            obiectComandaToBeUpdated.idObiectComanda = updatedObiectComanda.idObiectComanda;
            obiectComandaToBeUpdated.idComanda = updatedObiectComanda.idComanda;
            obiectComandaToBeUpdated.idProdus = updatedObiectComanda.idProdus;
            obiectComandaToBeUpdated.idClient = updatedObiectComanda.idClient;
            obiectComandaToBeUpdated.situatiePlata = updatedObiectComanda.situatiePlata;
            obiectComandaToBeUpdated.cantitateComanda = updatedObiectComanda.cantitateComanda;
            _ObiecteComandaServices.Update(obiectComandaToBeUpdated, updatedObiectComanda.idClient);
        }
        public void Delete(int id)
        {
            obiecteComanda obiectComandaToBeDeleted = _ObiecteComandaServices.Get(id);

            if (obiectComandaToBeDeleted == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            _ObiecteComandaServices.Delete(_ObiecteComandaServices.Get(id));
        }
    }
}
