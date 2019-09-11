using SteamApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SteamApp.Dtos;
using System.Data.Entity;

namespace SteamApp.Controllers.Api
{
    public class ClientsController : ApiController
    {
        private ApplicationDbContext _context;
        //GET /api/clients
        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetClients()
        {
            var clientDtos = _context.Clients
                .Include(c => c.ConsoleType)
                .ToList()
                .Select(Mapper.Map<Client, ClientDto>);

            return Ok(clientDtos);
           
        }


        //GET/api/clients/1

        public IHttpActionResult GetClient(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.ClientID == id);

            if(client == null)
            {
                return NotFound();
            }
            return Ok( Mapper.Map<Client,ClientDto>(client));
        }



        //POST / api/clients
        [HttpPost]
        public IHttpActionResult CreateClient(ClientDto clientDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var client = Mapper.Map<ClientDto, Client>(clientDto);
            _context.Clients.Add(client);
            _context.SaveChanges();

            clientDto.ClientID = client.ClientID;

            return Created(new Uri(Request.RequestUri+ "/" + client.ClientID),clientDto);
        }


        //PUT /api/clients/1
        [HttpPut]
        public void UpdateClient(int id,ClientDto clientDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var clientInDb = _context.Clients.SingleOrDefault(c => c.ClientID == id);

            if(clientInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            Mapper.Map(clientDto, clientInDb);
            

            _context.SaveChanges();
        }
        //Delete /api/client/1
        [HttpDelete]
        public void DeleteClient(int id)
        {
            var clientInDb = _context.Clients.SingleOrDefault(c => c.ClientID == id);

            if(clientInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Clients.Remove(clientInDb);
            _context.SaveChanges();
        }
    }
}
