using BusinessLayer_DBFirst;
using Exceptions;
using NivelAccessDate_DBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http;
using ViewModels;

namespace MarketplaceFermieri.Controllers
{
    public class VanzatorAPIController : ApiController
    {
        private IVanzator vanzatorAccesor;
        public VanzatorAPIController()
        {
            //vanzatorAccesor = new VanzatorServices();
        }
        public VanzatorAPIController(IVanzator vanzatorServices)
        {
            vanzatorAccesor = vanzatorServices;
        }

        [Route("api/Vanzator/Add")]
        [HttpPost]
        public IHttpActionResult Add(CreateVanzatorViewModel newVanzator)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vanzatorAccesor.Add(newVanzator);
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
                ReadVanzatorViewModel readVanzatorViewModel = vanzatorAccesor.Get(idVanzator);
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
                ReadVanzatorCardViewModel readVanzatorViewModel = vanzatorAccesor.GetCard(idVanzator);
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
                List<ReadVanzatorViewModel> readVanzatorViewModel = vanzatorAccesor.Get();
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
                List<ReadVanzatorCardViewModel> readVanzatorViewModel = vanzatorAccesor.GetAllCard();
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
        public IHttpActionResult Update(UpdateVanzatorViewModel vanzatorActualizat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vanzatorAccesor.Update(vanzatorActualizat);
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
                vanzatorAccesor.Delete(idVanzator);
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
                vanzatorAccesor.LogicalDelete(idVanzator);
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
