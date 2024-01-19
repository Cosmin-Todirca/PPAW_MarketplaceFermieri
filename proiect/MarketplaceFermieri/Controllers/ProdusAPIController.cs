using BusinessLayer_DBFirst;
using Exceptions;
using NivelAccessDate_DBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http;
using ViewModels;

namespace MarketplaceFermieri.Controllers
{
    public class ProdusAPIController : ApiController
    {
        private IProdus produsAccesor;
        public ProdusAPIController()
        {
            //produsAccesor = new ProdusServices();
        }
        public ProdusAPIController(IProdus produsServices)
        {
            produsAccesor = produsServices;
        }

        [Route("api/Produs/Add")]
        [HttpPost]
        public IHttpActionResult Add(CreateProdusViewModel newProdus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produsAccesor.Add(newProdus);
                    return Ok("Produs adaugat cu succes");
                }
                else
                {
                    return BadRequest("Eroare la adaugarea produsului");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la adaugarea produsului" + e.Message);

            }
        }

        [Route("api/Produs/Get")]
        [HttpGet]
        public IHttpActionResult Read(int idProdus)
        {
            try
            {
                ReadProdusViewModel readProdusViewModel = produsAccesor.Get(idProdus);
                return Ok(readProdusViewModel);
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la citirea produsului" + e.Message);
            }
        }
        [Route("api/Produs/GetAllCard")]
        [HttpGet]
        public IHttpActionResult Read()
        {
            try
            {
                List<ReadProdusCuVanzatorViewModel> readProdusCuVanzatorViewModel = produsAccesor.GetProduseCuVanzatori();
                return Ok(readProdusCuVanzatorViewModel);
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Ceva s-a intamplat " + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la citirea produselor cu vanzatori" + e.Message);
            }
        }


        [Route("api/Produs/Put")]
        [HttpPut]
        public IHttpActionResult Update(UpdateProdusViewModel produsActualizat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produsAccesor.Update(produsActualizat);
                    return Ok("Actualizarea produsului reusita!");
                }
                else
                {
                    return BadRequest("Eroare la actualizarea produsului");
                }
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la actualizarea produsului" + e.Message);
            }
        }

        [Route("api/Produs/Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int idProdus)
        {
            try
            {
                produsAccesor.Delete(idProdus);
                return Ok("Stergerea produsului realizata cu succes");
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la stergerea produsului" + e.Message);
            }
        }
    }
}
