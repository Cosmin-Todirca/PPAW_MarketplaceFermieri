//using Repository_CodeFirst;
using Accesor;
using BusinessLayer_DBFirst.Interfaces;
using DTOs;
using Exceptions;
using Repository_DBFirst;
using System.Collections.Generic;

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

        public void Add(CreateObiectComandaDTO newObiectComanda)
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

        public List<ReadObiectComandaDTO> Get()
        {
            List<obiecteComanda> bctCmnda = (List<obiecteComanda>)_ObiecteComandaServices.GetAll();

            if (bctCmnda == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            List<ReadObiectComandaDTO> readObiecteComanda = new List<ReadObiectComandaDTO>();
            foreach (obiecteComanda bctCmnd in bctCmnda) //not such a great implement, but enough for the moment
            {
                readObiecteComanda.Add(new ReadObiectComandaDTO()
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

        public ReadObiectComandaDTO Get(int Id)
        {
            obiecteComanda obiectComanda = _ObiecteComandaServices.Get(Id);

            if (obiectComanda == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            ReadObiectComandaDTO readObiectComandaViewModel = new ReadObiectComandaDTO()
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
        public void Update(UpdateObiectComandaDTO updatedObiectComanda)
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
