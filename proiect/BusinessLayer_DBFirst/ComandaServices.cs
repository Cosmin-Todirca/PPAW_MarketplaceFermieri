﻿//using Repository_CodeFirst;
using Accesor;
using BusinessLayer_DBFirst.Interfaces;
using DTOs;
using Exceptions;
using Repository_DBFirst;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer_DBFirst
{
    public class ComandaServices : IComanda
    {
        private marketplace_fermieriEntities _db;
        private ComenziAccesor _ComenziServices;

        public ComandaServices()
        {
            //_db = new marketplace_fermieriEntities();
            //_ComenziServices = new ComenziAccesor(_db);
        }

        public ComandaServices(IDBContext db)
        {
            _db = (marketplace_fermieriEntities)db;
            _ComenziServices = new ComenziAccesor(_db);
        }

        public void Add(CreateComandaDTO newComanda)
        {
            comenzi comanda = new comenzi()
            {
                idClient = newComanda.idClient,
                dataComanda = System.DateTime.Now,
                situatieComanda = newComanda.situatieComanda,
                total = newComanda.total
            };

            _ComenziServices.Add(comanda);
        }

        public List<ReadComandaDTO> Get()
        {
            List<comenzi> cmnzi = (List<comenzi>)_ComenziServices.GetAll();

            if (cmnzi == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            List<ReadComandaDTO> readComenzi = new List<ReadComandaDTO>();
            foreach (comenzi cmnd in cmnzi) //not such a great implement, but enough for the moment
            {
                readComenzi.Add(new ReadComandaDTO()
                {
                    idComanda = cmnd.idComanda,
                    idClient = cmnd.idClient,
                    dataComanda = cmnd.dataComanda,
                    situatieComanda = cmnd.situatieComanda,
                    total = cmnd.total

                });
            }
            return readComenzi;
        }

        public ReadComandaDTO Get(int Id)
        {
            comenzi comanda = _ComenziServices.Get(Id);

            if (comanda == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            ReadComandaDTO readComandaViewModel = new ReadComandaDTO()
            {
                idComanda = comanda.idComanda,
                idClient = comanda.idClient,
                dataComanda = comanda.dataComanda,
                situatieComanda = comanda.situatieComanda,
                total = comanda.total
            };
            return readComandaViewModel;
        }

        public ReadComandaDTO ReadNewOrder(int idClient)
        {
            comenzi comandaNoua = _ComenziServices.GetAllQuerable().Where(x => x.situatieComanda == "Nou" && x.idClient == idClient).FirstOrDefault();
            if (comandaNoua == null)
            {
                comenzi comanda = new comenzi()
                {
                    idClient = idClient,
                    dataComanda = System.DateTime.Now,
                    situatieComanda = "Nou",
                    total = 0
                };

                _ComenziServices.Add(comanda);
                comandaNoua = _ComenziServices.GetAllQuerable().Where(x => x.situatieComanda == "Nou" && x.idClient == idClient).FirstOrDefault();
                if (comandaNoua == null)
                {
                    throw new EntryNotFoundException("Eroare la preluarea unei comenzi noi.");
                }
            }
            
            ReadComandaDTO readComandaDTO = new ReadComandaDTO()
            {
                idComanda = comandaNoua.idComanda,
                idClient = comandaNoua.idClient,
                dataComanda = comandaNoua.dataComanda,
                situatieComanda = comandaNoua.situatieComanda,
                total = comandaNoua.total
            };
            return readComandaDTO;


        }

            public void Update(UpdateComandaDTO updatedComanda)
        {
            comenzi comandaToBeUpdated = _ComenziServices.Get(updatedComanda.idClient);

            if (comandaToBeUpdated == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            comandaToBeUpdated.idComanda = updatedComanda.idComanda;
            comandaToBeUpdated.idClient = updatedComanda.idClient;
            //comandaToBeUpdated.dataComanda = updatedComanda.dataComanda;
            comandaToBeUpdated.situatieComanda = updatedComanda.situatieComanda;
            comandaToBeUpdated.total = updatedComanda.total;
            _ComenziServices.Update(comandaToBeUpdated, updatedComanda.idClient);
        }
        public void Delete(int id)
        {
            comenzi comandaToBeDeleted = _ComenziServices.Get(id);

            if (comandaToBeDeleted == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            _ComenziServices.Delete(_ComenziServices.Get(id));
        }

    }
}
