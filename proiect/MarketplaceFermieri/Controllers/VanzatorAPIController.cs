using BusinessLayer_DBFirst.Interfaces;
using DTOs;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MarketplaceFermieri.Controllers
{
    public class VanzatorAPIController : ApiController
    {
        private IVanzator vanzatorServices;
        public VanzatorAPIController()
        {
            //vanzatorAccesor = new VanzatorServices();
        }
        public VanzatorAPIController(IVanzator vanzatorServices)
        {
            this.vanzatorServices = vanzatorServices;
        }

        [Route("api/Vanzator/Add")]
        [HttpPost]
        public IHttpActionResult Add(CreateVanzatorDTO newVanzator)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vanzatorServices.Add(newVanzator);
                    return Ok("Vanzator adaugat cu succes");
                }
                else
                {
                    return BadRequest("Eroare la adaugarea vanzatorului");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la adaugarea vanzatorului" + e.Message);

            }
        }

        [Route("api/Vanzator/Get")]
        [HttpGet]
        public IHttpActionResult Read(int idVanzator)
        {
            try
            {
                ReadVanzatorDTO readVanzatorViewModel = vanzatorServices.Get(idVanzator);
                return Ok(readVanzatorViewModel);
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la citirea vanzatorului" + e.Message);
            }
        }

        [Route("api/Vanzator/GetCard")]
        [HttpGet]
        public IHttpActionResult ReadCard(int idVanzator)
        {
            try
            {
                ReadVanzatorCardDTO readVanzatorViewModel = vanzatorServices.GetCard(idVanzator);
                return Ok(readVanzatorViewModel);
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la citirea card-vanzatorului" + e.Message);
            }
        }

        [Route("api/Vanzator/GetAll")]
        [HttpGet]
        public IHttpActionResult Read()
        {
            try
            {
                List<ReadVanzatorDTO> readVanzatorViewModel = vanzatorServices.Get();
                return Ok(readVanzatorViewModel);
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la citirea vanzatorilor" + e.Message);
            }
        }

        [Route("api/Vanzator/GetAllCard")]
        [HttpGet]
        public IHttpActionResult ReadAllCard()
        {
            try
            {
                List<ReadVanzatorCardDTO> readVanzatorViewModel = vanzatorServices.GetAllCard();
                return Ok(readVanzatorViewModel);
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la citirea vanzatorilor" + e.Message);
            }
        }

        [Route("api/Vanzator/Put")]
        [HttpPut]
        public IHttpActionResult Update(UpdateVanzatorDTO vanzatorActualizat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vanzatorServices.Update(vanzatorActualizat);
                    return Ok("Actualizarea vanzatorului reusita!");
                }
                else
                {
                    return BadRequest("Eroare la actualizarea vanzatorului");
                }
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la actualizarea vanzatorului" + e.Message);
            }
        }

        [Route("api/Vanzator/Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int idVanzator)
        {
            try
            {
                vanzatorServices.Delete(idVanzator);
                return Ok("Stergerea vanzatorului realizata cu succes");
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la stergerea vanzatorului" + e.Message);
            }
        }

        [Route("api/Vanzator/LogicalDelete")]
        [HttpDelete]
        public IHttpActionResult LogicalDelete(int idVanzator)
        {
            try
            {
                vanzatorServices.LogicalDelete(idVanzator);
                return Ok("Stergerea vanzatorului realizata cu succes");
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la stergerea vanzatorului" + e.Message);
            }
        }
    }
}
