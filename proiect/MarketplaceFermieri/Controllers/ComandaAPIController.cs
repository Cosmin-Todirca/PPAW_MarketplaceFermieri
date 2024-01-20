using BusinessLayer_DBFirst.Interfaces;
using DTOs;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MarketplaceFermieri.Controllers
{
    public class ComandaAPIController : ApiController
    {
        private IComanda comandaServices;
        public ComandaAPIController()
        {
            //comandaAccesor = new ComandaServices();
        }
        public ComandaAPIController(IComanda comandaServices)
        {
            this.comandaServices = comandaServices;
        }

        [Route("api/Comanda/Add")]
        [HttpPost]
        public IHttpActionResult Add(CreateComandaDTO newComanda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    comandaServices.Add(newComanda);
                    return Ok("Comanda adaugata cu succes");
                }
                else
                {
                    return BadRequest("Eroare la adaugarea comenzii");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la adaugarea comenzii" + e.Message);

            }
        }

        [Route("api/Comanda/Get")]
        [HttpGet]
        public IHttpActionResult Read(int idComanda)
        {
            try
            {
                ReadComandaDTO readComandaViewModel = comandaServices.Get(idComanda);
                return Ok(readComandaViewModel);
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la citirea comenzii" + e.Message);
            }
        }

        [Route("api/Comanda/GetAll")]
        [HttpGet]
        public IHttpActionResult Read()
        {
            try
            {
                List<ReadComandaDTO> readComandaViewModel = comandaServices.Get();
                return Ok(readComandaViewModel);
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la citirea comenzii" + e.Message);
            }
        }

        [Route("api/Comanda/GetNewOrder")]
        [HttpGet]
        public IHttpActionResult ReadNewOrder(int idClient)
        {
            try
            {
                ReadComandaDTO readComandaDTO = comandaServices.ReadNewOrder(idClient);
                return Ok(readComandaDTO);
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la citirea comenzii" + e.Message);
            }
        }


        [Route("api/Comanda/Put")]
        [HttpPut]
        public IHttpActionResult Update(UpdateComandaDTO comandaActualizata)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    comandaServices.Update(comandaActualizata);
                    return Ok("Actualizarea comenzii reusita!");
                }
                else
                {
                    return BadRequest("Eroare la actualizarea comenzii");
                }
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la actualizarea comenzii" + e.Message);
            }
        }

        [Route("api/Comanda/Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int idComanda)
        {
            try
            {
                comandaServices.Delete(idComanda);
                return Ok("Stergerea comenzii realizata cu succes");
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la stergerea comenzii" + e.Message);
            }
        }

    }
}
