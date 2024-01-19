using BusinessLayer_DBFirst;
using Exceptions;
using NivelAccessDate_DBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http;
using ViewModels;

namespace MarketplaceFermieri.Controllers
{
    public class ClientAPIController : ApiController
    {
        private IClient clientAccesor;
        public ClientAPIController()
        {
            //clientAccesor = new ClientServices();
        }
        public ClientAPIController(IClient clientServices)
        {
            clientAccesor = clientServices;
        }

        [Route("api/Client/Add")]
        [HttpPost]
        public IHttpActionResult Add(CreateClientViewModel newClient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clientAccesor.Add(newClient);
                    return Ok("Client adaugat cu succes");
                }
                else
                {
                    return BadRequest("Eroare la adaugarea clientului");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la adaugarea clientului" + e.Message);

            }
        }

        [Route("api/Client/Get")]
        [HttpGet]
        public IHttpActionResult Read(int idClient)
        {
            try
            {
                ReadClientViewModel readClientViewModel = clientAccesor.Get(idClient);
                return Ok(readClientViewModel);
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la citirea clientului" + e.Message);
            }
        }

        [Route("api/Client/GetAll")]
        [HttpGet]
        public IHttpActionResult Read()
        {
            try
            {
                List<ReadClientViewModel> readClientViewModel = clientAccesor.Get();
                return Ok(readClientViewModel);
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la citirea clientilor" + e.Message);
            }
        }


        [Route("api/Client/Put")]
        [HttpPut]
        public IHttpActionResult Update(UpdateClientViewModel clientActualizat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clientAccesor.Update(clientActualizat);
                    return Ok("Actualizarea clientului reusita!");
                }
                else
                {
                    return BadRequest("Eroare la actualizarea clientului");
                }
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la actualizarea clientului" + e.Message);
            }
        }

        [Route("api/Client/Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int idClient)
        {
            try
            {
                clientAccesor.Delete(idClient);
                return Ok("Stergerea clientului realizata cu succes");
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la stergerea clientului" + e.Message);
            }
        }

    }
}
