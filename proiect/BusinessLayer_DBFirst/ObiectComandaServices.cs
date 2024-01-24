//using Repository_CodeFirst;
using Accesor;
using BusinessLayer_DBFirst.Interfaces;
using DTOs;
using Exceptions;
using Repository_DBFirst;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer_DBFirst
{
    public class ObiectComandaServices : IObiectComanda
    {
        private marketplace_fermieriEntities _db;
        private ObiecteComandaAccesor _ObiecteComandaServices;
        private ProduseAccesor _ProduseAccesor;


        public ObiectComandaServices()
        {
            //_db = new marketplace_fermieriEntities();
            //_ObiecteComandaServices = new ObiecteComandaAccesor(_db);
        }

        public ObiectComandaServices(IDBContext db)
        {
            _db = (marketplace_fermieriEntities)db;
            _ObiecteComandaServices = new ObiecteComandaAccesor(_db);
            _ProduseAccesor = new ProduseAccesor(_db);
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

        public void AddToCart(CreateObiectComandaDTO newObiectComanda) //BUSINESSLOGIC. Daca obiectul de comanda exista, doar se actualizeaza cantitatea
        {
            bool gasit = false;
            obiecteComanda obiectComanda = new obiecteComanda()
            {
                idComanda = newObiectComanda.idComanda,
                idProdus = newObiectComanda.idProdus,
                idClient = newObiectComanda.idClient,
                situatiePlata = newObiectComanda.situatiePlata,
                cantitateComanda = newObiectComanda.cantitateComanda
            };
            List<obiecteComanda> obtComanda = _ObiecteComandaServices.GetAll().Where(x=> x.idComanda== obiectComanda.idComanda).ToList();
            for(int i = 0; i < obtComanda.Count; i++)
            {
                if (obiectComanda.idProdus == obtComanda[i].idProdus)
                {
                    gasit = true;
                    obiectComanda.idObiectComanda = obtComanda[i].idObiectComanda;
                    obiectComanda.cantitateComanda += obtComanda[i].cantitateComanda;
                }
            }
            produse prd = _ProduseAccesor.Get(obiectComanda.idProdus); //verific sa nu depasim stockul
            if(obiectComanda.cantitateComanda>prd.cantitate)
            {
                obiectComanda.cantitateComanda = prd.cantitate;
            }

            if (!gasit)
            {
                _ObiecteComandaServices.Add(obiectComanda);
            }
            else
            {
                _ObiecteComandaServices.Update(obiectComanda, obiectComanda.idObiectComanda);
            }
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

        public ReadObiectComandaCartDTO Get(int idComanda, int idClient) //BUSINESSLOGIC get items from cart for placing the order
        {
            List<obiecteComanda> bctCmnda = _ObiecteComandaServices.GetAll().Where(x => x.idComanda==idComanda && x.idClient==idClient ).ToList();

            if (bctCmnda == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            List<ReadObiectComandaCuProdusDTO> readObiecteComanda = new List<ReadObiectComandaCuProdusDTO>();
            decimal transportPrice = Constants.transportPrice;
            decimal totalDiscount = 0;
            decimal totalPrice = 0;
            foreach (obiecteComanda bctCmnd in bctCmnda) //not such a great implement, but enough for the moment
            {
                produse produsCumparat = _ProduseAccesor.Get(bctCmnd.idProdus);
                ReadProdusDTO prd = new ReadProdusDTO()
                {
                    idProdus = produsCumparat.idProdus,
                    idVanzator = produsCumparat.idVanzator,
                    numeProdus = produsCumparat.numeProdus,
                    descriereProdus = produsCumparat.descriereProdus,
                    pret = produsCumparat.pret,
                    unitateDeMasura = produsCumparat.unitateDeMasura,
                    cantitate = produsCumparat.cantitate,
                    imagine = produsCumparat.imagine
                };
                readObiecteComanda.Add(new ReadObiectComandaCuProdusDTO()
                {
                    idObiectComanda = bctCmnd.idObiectComanda,
                    idComanda = bctCmnd.idComanda,
                    idProdus = bctCmnd.idProdus,
                    idClient = bctCmnd.idClient,
                    situatiePlata = bctCmnd.situatiePlata,
                    cantitateComanda = bctCmnd.cantitateComanda,
                    produs = prd
                });
                totalPrice += prd.pret * bctCmnd.cantitateComanda;
            }
            if(totalPrice > Constants.storeOfferFreeTransportTargetPrice) {
                totalDiscount = transportPrice;
            }
            ReadObiectComandaCartDTO cart = new ReadObiectComandaCartDTO();
            cart.obiecteComanda = readObiecteComanda;
            cart.transportPrice= transportPrice;
            cart.totalDiscount = totalDiscount;
            cart.totalPriceWithoutTransport = totalPrice;
            cart.totalPrice = totalPrice + transportPrice - totalDiscount;

            return cart;
        }
            public void Update(UpdateObiectComandaDTO updatedObiectComanda)
        {
            obiecteComanda obiectComandaToBeUpdated = _ObiecteComandaServices.Get(updatedObiectComanda.idObiectComanda);

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
            _ObiecteComandaServices.Update(obiectComandaToBeUpdated, updatedObiectComanda.idObiectComanda);
        }

        public void UpdateObiectComanda(UpdateObiectComandaDTO updatedObiectComanda)
        {
            obiecteComanda obiectComandaToBeUpdated = _ObiecteComandaServices.Get(updatedObiectComanda.idObiectComanda);

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

            produse prd = _ProduseAccesor.Get(obiectComandaToBeUpdated.idProdus); //verific sa nu depasim stockul
            if (obiectComandaToBeUpdated.cantitateComanda > prd.cantitate)
            {
                obiectComandaToBeUpdated.cantitateComanda = prd.cantitate;
            }
            _ObiecteComandaServices.Update(obiectComandaToBeUpdated, updatedObiectComanda.idObiectComanda);
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
