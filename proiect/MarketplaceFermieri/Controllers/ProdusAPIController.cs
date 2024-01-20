using BusinessLayer_DBFirst.Interfaces;
using DTOs;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MarketplaceFermieri.Controllers
{
    public class ProdusAPIController : ApiController
    {
        private IProdus produsServices;
        public ProdusAPIController()
        {
            //produsAccesor = new ProdusServices();
        }
        public ProdusAPIController(IProdus produsServices)
        {
            this.produsServices = produsServices;
        }

        [Route("api/Produs/Add")]
        [HttpPost]
        public IHttpActionResult Add(CreateProdusDTO newProdus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produsServices.Add(newProdus);
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
                ReadProdusDTO readProdusViewModel = produsServices.Get(idProdus);
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
                List<ReadProdusCuVanzatorDTO> readProdusCuVanzatorViewModel = produsServices.GetProduseCuVanzatori();
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
        public IHttpActionResult Update(UpdateProdusDTO produsActualizat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produsServices.Update(produsActualizat);
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
                produsServices.Delete(idProdus);
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
