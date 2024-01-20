//using Repository_CodeFirst;
using Accesor;
using BusinessLayer_DBFirst.Interfaces;
using DTOs;
using Exceptions;
using Repository_DBFirst;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer_DBFirst
{
    public class ProdusServices : IProdus
    {
        private marketplace_fermieriEntities _db;
        private ProduseAccesor _ProduseServices;
        private VanzatoriAccesor _VanzatoriServices;
        ArrayList listaUnitateDeMasura = new ArrayList() { "kilogram", "bucata", "litru", "legatura" };

        public ProdusServices()
        {
            //_db = new marketplace_fermieriEntities();
            //_ProduseServices = new ProduseAccesor(_db);
            //_VanzatoriServices = new VanzatoriAccesor(_db);
        }

        public ProdusServices(IDBContext db)
        {
            _db = (marketplace_fermieriEntities)db;
            _ProduseServices = new ProduseAccesor(_db);
            _VanzatoriServices = new VanzatoriAccesor(_db);
        }

        public void Add(CreateProdusDTO newProdus)
        {
            produse produs = new produse()
            {
                idVanzator = newProdus.idVanzator,
                numeProdus = newProdus.numeProdus,
                descriereProdus = newProdus.descriereProdus,
                pret = newProdus.pret,
                unitateDeMasura = newProdus.unitateDeMasura,
                cantitate = newProdus.cantitate,
                imagine = newProdus.imagine
            };

            if (listaUnitateDeMasura.Contains(produs.unitateDeMasura))
            {
                _ProduseServices.Add(produs);
            }
            else
            {
                Console.WriteLine("Unitate de masura gresita");
            }
        }

        public List<ReadProdusDTO> Get()
        {
            List<produse> prdse = (List<produse>)_ProduseServices.GetAll();

            if (prdse == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            List<ReadProdusDTO> readProduse = new List<ReadProdusDTO>();
            foreach (produse prd in prdse) //not such a great implement, but enough for the moment
            {
                readProduse.Add(new ReadProdusDTO()
                {
                    idProdus = prd.idProdus,
                    idVanzator = prd.idVanzator,
                    numeProdus = prd.numeProdus,
                    descriereProdus = prd.descriereProdus,
                    pret = prd.pret,
                    unitateDeMasura = prd.unitateDeMasura,
                    cantitate = prd.cantitate,
                    imagine = prd.imagine

                });
            }
            return readProduse;
        }

        public ReadProdusDTO Get(int Id)
        {
            produse produs = _ProduseServices.Get(Id);

            if (produs == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            ReadProdusDTO readProdusViewModel = new ReadProdusDTO()
            {
                idProdus = produs.idProdus,
                idVanzator = produs.idVanzator,
                numeProdus = produs.numeProdus,
                descriereProdus = produs.descriereProdus,
                pret = produs.pret,
                unitateDeMasura = produs.unitateDeMasura,
                cantitate = produs.cantitate,
                imagine = produs.imagine
            };
            return readProdusViewModel;
        }
        public void Update(UpdateProdusDTO updatedProdus)
        {
            produse produsToBeUpdated = _ProduseServices.Get(updatedProdus.idProdus);

            if (produsToBeUpdated == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            produsToBeUpdated.idProdus = updatedProdus.idProdus;
            produsToBeUpdated.idVanzator = updatedProdus.idVanzator;
            produsToBeUpdated.numeProdus = updatedProdus.numeProdus;
            produsToBeUpdated.descriereProdus = updatedProdus.descriereProdus;
            produsToBeUpdated.pret = updatedProdus.pret;
            produsToBeUpdated.unitateDeMasura = updatedProdus.unitateDeMasura;
            produsToBeUpdated.cantitate = updatedProdus.cantitate;
            produsToBeUpdated.imagine = updatedProdus.imagine;
            if (listaUnitateDeMasura.Contains(produsToBeUpdated.unitateDeMasura))
            {
                _ProduseServices.Update(produsToBeUpdated, updatedProdus.idProdus);
            }
            else
            {
                Console.WriteLine("Unitate de masura gresita");
            }
        }
        public void Delete(int id)
        {
            produse produsToBeDeleted = _ProduseServices.Get(id);

            if (produsToBeDeleted == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            _ProduseServices.Delete(_ProduseServices.Get(id));
        }

        public ReadProdusCuVanzatorDTO GetProdusCuVanzator(int Id)
        {

            produse produs = _ProduseServices.Get(Id);

            if (produs == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            ReadProdusCuVanzatorDTO readProdusCuVanzator = new ReadProdusCuVanzatorDTO()
            {
                idProdus = produs.idProdus,
                idVanzator = produs.idVanzator,
                numeProdus = produs.numeProdus,
                descriereProdus = produs.descriereProdus,
                pret = produs.pret,
                unitateDeMasura = produs.unitateDeMasura,
                cantitate = produs.cantitate,
                imagine = produs.imagine
            };

            vanzatori vanzator = _VanzatoriServices.GetAllQuerable().Where(x => x.idVanzator == produs.idVanzator).FirstOrDefault();
            ReadVanzatorDTO vanzatorViewModel = new ReadVanzatorDTO()
            {
                idVanzator = vanzator.idVanzator,
                numeVanzator = vanzator.numeVanzator,
                prenumeVanzator = vanzator.prenumeVanzator,
                email = vanzator.email,
                numarTelefon = vanzator.numarTelefon
            };
            if (vanzator != null)
                readProdusCuVanzator.vanzator = vanzatorViewModel;


            return readProdusCuVanzator;
        }

        public ReadProdusCuVanzatorDTO readProdusCuVanzatorEager(int id)
        {
            var produs = _ProduseServices.GetProduseWithVanzatori(id);


            if (produs == null)
            {
                throw new EntryNotFoundException("Id inexistent");

            }

            var produsViewModel = new ReadProdusCuVanzatorDTO
            {
                idProdus = produs.idProdus,
                idVanzator = produs.idVanzator,
                numeProdus = produs.numeProdus,
                descriereProdus = produs.descriereProdus,
                pret = produs.pret,
                unitateDeMasura = produs.unitateDeMasura,
                cantitate = produs.cantitate,
                imagine = produs.imagine,
                vanzator = new ReadVanzatorDTO
                {
                    idVanzator = produs.vanzatori.idVanzator,
                    numeVanzator = produs.vanzatori.numeVanzator,
                    prenumeVanzator = produs.vanzatori.prenumeVanzator,
                    numarTelefon = produs.vanzatori.numarTelefon,
                    email = produs.vanzatori.email
                }
            };

            return produsViewModel;
        }
        public List<ReadProdusCuVanzatorDTO> GetProduseCuVanzatori()
        {

            List<produse> prdse = (List<produse>)_ProduseServices.GetAll();

            if (prdse == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            List<ReadProdusCuVanzatorDTO> readProduseCuVanzatori = new List<ReadProdusCuVanzatorDTO>();
            foreach (produse prd in prdse) //not such a great implement, but enough for the moment
            {
                vanzatori vanzator = _VanzatoriServices.GetAllQuerable().Where(x => x.idVanzator == prd.idVanzator).FirstOrDefault();
                ReadVanzatorDTO vanzatorViewModel = new ReadVanzatorDTO()
                {
                    idVanzator = vanzator.idVanzator,
                    numeVanzator = vanzator.numeVanzator,
                    prenumeVanzator = vanzator.prenumeVanzator,
                    email = vanzator.email,
                    numarTelefon = vanzator.numarTelefon
                };
                if (vanzator != null)
                {
                    readProduseCuVanzatori.Add(new ReadProdusCuVanzatorDTO()
                    {
                        idProdus = prd.idProdus,
                        idVanzator = prd.idVanzator,
                        numeProdus = prd.numeProdus,
                        descriereProdus = prd.descriereProdus,
                        pret = prd.pret,
                        unitateDeMasura = prd.unitateDeMasura,
                        cantitate = prd.cantitate,
                        imagine = prd.imagine,
                        vanzator = vanzatorViewModel

                    });
                }
            }

            return readProduseCuVanzatori;
        }

        public void AddCuDropdown(CreateProdusCuDropdownDTO newProdus)
        {
            produse produs = new produse()
            {
                idVanzator = newProdus.idVanzator,
                numeProdus = newProdus.numeProdus,
                descriereProdus = newProdus.descriereProdus,
                pret = newProdus.pret,
                unitateDeMasura = newProdus.unitateDeMasura,
                cantitate = newProdus.cantitate,
                imagine = newProdus.imagine
            };

            if (listaUnitateDeMasura.Contains(produs.unitateDeMasura))
            {
                _ProduseServices.Add(produs);
            }
            else
            {
                Console.WriteLine("Unitate de masura gresita");
            }
        }
    }
}
