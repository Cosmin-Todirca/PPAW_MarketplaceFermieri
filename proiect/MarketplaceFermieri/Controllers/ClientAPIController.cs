using BusinessLayer_DBFirst.Interfaces;
using DTOs;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MarketplaceFermieri.Controllers
{
    public class ClientAPIController : ApiController
    {
        private IClient clientServices;
        public ClientAPIController()
        {
            //clientAccesor = new ClientServices();
        }
        public ClientAPIController(IClient clientServices)
        {
            this.clientServices = clientServices;
        }

        [Route("api/Client/Add")]
        [HttpPost]
        public IHttpActionResult Add(CreateClientDTO newClient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clientServices.Add(newClient);
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
                ReadClientDTO readClientViewModel = clientServices.Get(idClient);
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
                List<ReadClientDTO> readClientViewModel = clientServices.Get();
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
        public IHttpActionResult Update(UpdateClientDTO clientActualizat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clientServices.Update(clientActualizat);
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
                clientServices.Delete(idClient);
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
