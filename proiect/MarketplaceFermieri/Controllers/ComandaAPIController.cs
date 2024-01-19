using BusinessLayer_DBFirst;
using Exceptions;
using NivelAccessDate_DBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http;
using ViewModels;

namespace MarketplaceFermieri.Controllers
{
    public class ComandaAPIController : ApiController
    {
        private IComanda comandaAccesor;
        public ComandaAPIController()
        {
            //comandaAccesor = new ComandaServices();
        }
        public ComandaAPIController(IComanda comandaServices)
        {
            comandaAccesor = comandaServices;
        }

        [Route("api/Comanda/Add")]
        [HttpPost]
        public IHttpActionResult Add(CreateComandaViewModel newComanda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    comandaAccesor.Add(newComanda);
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
                ReadComandaViewModel readComandaViewModel = comandaAccesor.Get(idComanda);
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
                List<ReadComandaViewModel> readComandaViewModel = comandaAccesor.Get();
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

        [Route("api/Comanda/Put")]
        [HttpPut]
        public IHttpActionResult Update(UpdateComandaViewModel comandaActualizata)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    comandaAccesor.Update(comandaActualizata);
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
                comandaAccesor.Delete(idComanda);
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
