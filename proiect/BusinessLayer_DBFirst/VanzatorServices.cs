using Accesor;
using AutoMapper;
using BusinessLayer_DBFirst.Interfaces;
using DTOs;
//using Repository_CodeFirst;
using Exceptions;
using Repository_DBFirst;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer_DBFirst
{
    public class VanzatorServices : IVanzator
    {
        private marketplace_fermieriEntities _db;
        private VanzatoriAccesor _VanzatoriServices;
        MapperConfiguration config;
        IMapper mapper;

        public VanzatorServices()
        {
            //_db = new marketplace_fermieriEntities();
            //_VanzatoriServices = new VanzatoriAccesor(_db);
            //config = MapperConfig.InitializeAutomapper();
            //mapper = config.CreateMapper();
        }

        public VanzatorServices(IDBContext db)
        {
            _db = (marketplace_fermieriEntities)db;
            _VanzatoriServices = new VanzatoriAccesor(_db);
            config = MapperConfig.InitializeAutomapper();
            mapper = config.CreateMapper();
        }


        public void Add(CreateVanzatorDTO newVanzator)
        {
            vanzatori vanzator = new vanzatori()
            {
                numeVanzator = newVanzator.numeVanzator,
                prenumeVanzator = newVanzator.prenumeVanzator,
                email = newVanzator.email,
                numarTelefon = newVanzator.numarTelefon,
                logicalDelete = newVanzator.logicalDelete
            };

            _VanzatoriServices.Add(vanzator);
        }

        public List<ReadVanzatorDTO> Get()
        {
            List<vanzatori> vnztri = (List<vanzatori>)_VanzatoriServices.GetAllQuerable().Where(x => x.logicalDelete == false).ToList();

            if (vnztri == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            List<ReadVanzatorDTO> readVanzatori = new List<ReadVanzatorDTO>();
            foreach (vanzatori vnztr in vnztri) //not such a great implement, but enough for the moment
            {
                readVanzatori.Add(new ReadVanzatorDTO()
                {
                    idVanzator = vnztr.idVanzator,
                    numeVanzator = vnztr.numeVanzator,
                    prenumeVanzator = vnztr.prenumeVanzator,
                    email = vnztr.email,
                    numarTelefon = vnztr.numarTelefon,
                    logicalDelete = vnztr.logicalDelete

                });
            }
            return readVanzatori;
        }

        public ReadVanzatorDTO Get(int Id)
        {
            vanzatori vanzator = _VanzatoriServices.GetAllQuerable().Where(x => x.idVanzator == Id && x.logicalDelete == false).First();

            if (vanzator == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            ReadVanzatorDTO readVanzatorViewModel = new ReadVanzatorDTO()
            {
                idVanzator = vanzator.idVanzator,
                numeVanzator = vanzator.numeVanzator,
                prenumeVanzator = vanzator.prenumeVanzator,
                email = vanzator.email,
                numarTelefon = vanzator.numarTelefon,
                logicalDelete = vanzator.logicalDelete
            };
            return readVanzatorViewModel;
        }

        public ReadVanzatorCardDTO GetCard(int Id)
        {
            vanzatori vanzator = _VanzatoriServices.GetAllQuerable().Where(x => x.idVanzator == Id && x.logicalDelete == false).First();

            if (vanzator == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }
            /*
            Mapper.Initialize(cfg =>
            {
                // Add your mapping configuration here
                cfg.CreateMap<vanzatori, ReadVanzatorCardViewModel>();
                // Any other mapping configuration
            });
           

            var card = Mapper.Map<vanzatori, ReadVanzatorCardViewModel>(vanzator);
            */

            var card = mapper.Map<vanzatori, ReadVanzatorCardDTO>(vanzator);

            return card;
        }
        public List<ReadVanzatorCardDTO> GetAllCard()
        {
            List<vanzatori> vnztri = (List<vanzatori>)_VanzatoriServices.GetAllQuerable().Where(x => x.logicalDelete == false).ToList();

            if (vnztri == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            List<ReadVanzatorCardDTO> readVanzatori = new List<ReadVanzatorCardDTO>();
            foreach (vanzatori vnztr in vnztri) //not such a great implement, but enough for the moment
            {
                readVanzatori.Add(mapper.Map<vanzatori, ReadVanzatorCardDTO>(vnztr));
            }
            return readVanzatori;
        }

        public void Update(UpdateVanzatorDTO updatedVanzator)
        {
            vanzatori vanzatorToBeUpdated = _VanzatoriServices.GetAllQuerable().Where(x => x.idVanzator == updatedVanzator.idVanzator && x.logicalDelete == false).First();

            if (vanzatorToBeUpdated == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            vanzatorToBeUpdated.idVanzator = updatedVanzator.idVanzator;
            vanzatorToBeUpdated.numeVanzator = updatedVanzator.numeVanzator;
            vanzatorToBeUpdated.prenumeVanzator = updatedVanzator.prenumeVanzator;
            vanzatorToBeUpdated.email = updatedVanzator.email;
            vanzatorToBeUpdated.numarTelefon = updatedVanzator.numarTelefon;
            vanzatorToBeUpdated.logicalDelete = updatedVanzator.logicalDelete;
            _VanzatoriServices.Update(vanzatorToBeUpdated, updatedVanzator.idVanzator);
        }
        public void Delete(int id)
        {
            vanzatori vanzatorToBeDeleted = _VanzatoriServices.Get(id);

            if (vanzatorToBeDeleted == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            _VanzatoriServices.Delete(_VanzatoriServices.Get(id));
        }
        public void LogicalDelete(int id)
        {
            vanzatori vanzatorToBeDeleted = _VanzatoriServices.GetAllQuerable().Where(x => x.idVanzator == id && x.logicalDelete == false).First();

            if (vanzatorToBeDeleted == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }
            vanzatorToBeDeleted.logicalDelete = true;

            _VanzatoriServices.Update(vanzatorToBeDeleted, id);
        }

        public List<ReadVanzatorDTO> GetAll()
        {
            var listaVanzatori = _VanzatoriServices.GetAllQuerable().Select(x => new ReadVanzatorDTO()
            {
                idVanzator = x.idVanzator,
                numeVanzator = x.numeVanzator,
                prenumeVanzator = x.prenumeVanzator,
                email = x.email,
                numarTelefon = x.numarTelefon
            }).ToList();

            return listaVanzatori;
        }
    }
}

