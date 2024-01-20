using BusinessLayer_DBFirst.Interfaces;
using DTOs;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MarketplaceFermieri.Controllers
{
    public class ObiectComandaAPIController : ApiController
    {
        private IObiectComanda obiectComandaServices;

        public ObiectComandaAPIController()
        {
            //obiectComandaAccesor = new ObiectComandaServices();
        }
        public ObiectComandaAPIController(IObiectComanda obiectComandaServices)
        {
            this.obiectComandaServices = obiectComandaServices;
        }


        [Route("api/ObiectComanda/Add")]
        [HttpPost]
        public IHttpActionResult Add(CreateObiectComandaDTO newObiectComanda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obiectComandaServices.Add(newObiectComanda);
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

        [Route("api/ObiectComanda/AddToCart")]
        [HttpPost]
        public IHttpActionResult AddToCart(CreateObiectComandaDTO newObiectComanda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obiectComandaServices.AddToCart(newObiectComanda);
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
                ReadObiectComandaDTO readObiectComandaViewModel = obiectComandaServices.Get(idObiectComanda);
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
                List<ReadObiectComandaDTO> readObiectComandaViewModel = obiectComandaServices.Get();
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
        public IHttpActionResult Update(UpdateObiectComandaDTO obiectComandaActualizat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obiectComandaServices.Update(obiectComandaActualizat);
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
                obiectComandaServices.Delete(idObiectComanda);
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
