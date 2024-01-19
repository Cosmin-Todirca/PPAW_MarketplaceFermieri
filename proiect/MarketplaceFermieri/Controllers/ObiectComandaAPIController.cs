using BusinessLayer_DBFirst;
using Exceptions;
using NivelAccessDate_DBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http;
using ViewModels;

namespace MarketplaceFermieri.Controllers
{
    public class ObiectComandaAPIController : ApiController
    {
        private IObiectComanda obiectComandaAccesor;

        public ObiectComandaAPIController()
        {
            //obiectComandaAccesor = new ObiectComandaServices();
        }
        public ObiectComandaAPIController(IObiectComanda obiectComandaServices)
        {
            obiectComandaAccesor = obiectComandaServices;
        }


        [Route("api/ObiectComanda/Add")]
        [HttpPost]
        public IHttpActionResult Add(CreateObiectComandaViewModel newObiectComanda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obiectComandaAccesor.Add(newObiectComanda);
                    return Ok("Obiectul unei comenzi adaugat cu succes");
                }
                else
                {
                    return BadRequest("Eroare la adaugarea obiectului unei comenzi");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la adaugarea obiectului unei comenzi" + e.Message);

            }
        }

        [Route("api/ObiectComanda/Get")]
        [HttpGet]
        public IHttpActionResult Read(int idObiectComanda)
        {
            try
            {
                ReadObiectComandaViewModel readObiectComandaViewModel = obiectComandaAccesor.Get(idObiectComanda);
                return Ok(readObiectComandaViewModel);
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la citirea obiectului unei comenzi" + e.Message);
            }
        }

        [Route("api/ObiectComanda/GetAll")]
        [HttpGet]
        public IHttpActionResult Read()
        {
            try
            {
                List<ReadObiectComandaViewModel> readObiectComandaViewModel = obiectComandaAccesor.Get();
                return Ok(readObiectComandaViewModel);
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la citirea tuturor obiectelor" + e.Message);
            }
        }

        [Route("api/ObiectComanda/Put")]
        [HttpPut]
        public IHttpActionResult Update(UpdateObiectComandaViewModel obiectComandaActualizat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obiectComandaAccesor.Update(obiectComandaActualizat);
                    return Ok("Actualizarea obiectului unei comenzi reusit!");
                }
                else
                {
                    return BadRequest("Eroare la actualizarea obiectului unei comenzi");
                }
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la actualizarea obiectului unei comenzi" + e.Message);
            }
        }

        [Route("api/ObiectComanda/Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int idObiectComanda)
        {
            try
            {
                obiectComandaAccesor.Delete(idObiectComanda);
                return Ok("Stergerea obiectului unei comenzi realizat cu succes");
            }
            catch (EntryNotFoundException e)
            {
                return BadRequest("Id inexistent" + e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Exceptie la stergerea obiectului unei comenzi" + e.Message);
            }
        }
    }
}
