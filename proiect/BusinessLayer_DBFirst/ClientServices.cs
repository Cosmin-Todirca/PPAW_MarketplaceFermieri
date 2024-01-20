//using Repository_CodeFirst;
using Accesor;
using BusinessLayer_DBFirst.Interfaces;
using DTOs;
using Exceptions;
using Repository_DBFirst;
using System;
using System.Collections.Generic;

namespace BusinessLayer_DBFirst
{
    public class ClientServices : IClient
    {
        private marketplace_fermieriEntities _db;
        private ClientiAccesor _ClientiServices;
        private ICache cacheManager;

        public ClientServices()
        {
            //_db = new marketplace_fermieriEntities();
            //_ClientiServices = new ClientiAccesor(_db);
        }

        public ClientServices(IDBContext db, ICache cacheManager)
        {
            _db = (marketplace_fermieriEntities)db;
            _ClientiServices = new ClientiAccesor(_db);
            this.cacheManager = cacheManager;
        }

        public void Add(CreateClientDTO newClient)
        {
            try
            {
                clienti client = new clienti()
                {
                    numeClient = newClient.numeClient,
                    prenumeClient = newClient.prenumeClient,
                    email = newClient.email,
                    numarTelefon = newClient.numarTelefon
                };

                _ClientiServices.Add(client);
                cacheManager.Remove("clienti");
            }
            catch (Exception)
            {
                throw new EntityValidationException("Eroare la adaugarea clientului");
            }
        }

        public List<ReadClientDTO> Get()
        {
            List<clienti> clnti;
            if (cacheManager.IsSet("clienti"))
            {
                clnti = cacheManager.Get<List<clienti>>("clienti");
            }
            else
            {
                clnti = (List<clienti>)_ClientiServices.GetAll();
                cacheManager.Set("clienti", clnti);
            }
            if (clnti == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            List<ReadClientDTO> readClienti = new List<ReadClientDTO>();
            foreach (clienti clnt in clnti) //not such a great implement, but enough for the moment
            {
                readClienti.Add(new ReadClientDTO()
                {
                    idClient = clnt.idClient,
                    numeClient = clnt.numeClient,
                    prenumeClient = clnt.prenumeClient,
                    email = clnt.email,
                    numarTelefon = clnt.numarTelefon

                });
            }
            return readClienti;
        }

        public ReadClientDTO Get(int Id)
        {
            clienti client;
            if (cacheManager.IsSet("client_" + Id))
            {
                client = cacheManager.Get<clienti>("client_" + Id);
            }
            else
            {
                client = _ClientiServices.Get(Id);
                cacheManager.Set("client_" + Id, client);

            }
            if (client == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            ReadClientDTO readClientViewModel = new ReadClientDTO()
            {
                idClient = client.idClient,
                numeClient = client.numeClient,
                prenumeClient = client.prenumeClient,
                email = client.email,
                numarTelefon = client.numarTelefon
            };
            return readClientViewModel;
        }
        public void Update(UpdateClientDTO updatedClient)
        {
            clienti clientToBeUpdated = _ClientiServices.Get(updatedClient.idClient);

            if (clientToBeUpdated == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            clientToBeUpdated.idClient = updatedClient.idClient;
            clientToBeUpdated.numeClient = updatedClient.numeClient;
            clientToBeUpdated.prenumeClient = updatedClient.prenumeClient;
            clientToBeUpdated.email = updatedClient.email;
            clientToBeUpdated.numarTelefon = updatedClient.numarTelefon;
            _ClientiServices.Update(clientToBeUpdated, updatedClient.idClient);
            cacheManager.Remove("clienti");
            cacheManager.Remove("client+" + updatedClient.idClient);

        }
        public void Delete(int id)
        {
            clienti clientToBeDeleted = _ClientiServices.Get(id);

            if (clientToBeDeleted == null)
            {
                throw new EntryNotFoundException("Id inexistent");
            }

            _ClientiServices.Delete(_ClientiServices.Get(id));
            cacheManager.Remove("clienti");
            cacheManager.Remove("client+" + id);
        }
    }
}
