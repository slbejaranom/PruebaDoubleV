using TicketApi.Models;
using TicketApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TicketApi.Controllers{

    [Route ("api/ticket")]
    [ApiController]
    public class TicketsController : ControllerBase{
        private readonly TicketService _ticketService;

        public TicketsController(TicketService ticketService){
            _ticketService = ticketService;
        }

        [HttpGet]
        public ActionResult<List<Ticket>> Get() =>
            _ticketService.Get();       

        [HttpGet("{id}", Name = "GetTicket")] 
        public ActionResult<Ticket> Get(string id){
            var ticket = _ticketService.Get(id);

            if(ticket == null){
                return NotFound();
            }
            
            return ticket;
        }

        [HttpPost]
        public ActionResult<Ticket> Create(Ticket ticket){
            _ticketService.Create(ticket);

            return CreatedAtRoute("GetTicket", new { id = ticket.id.ToString() }, ticket);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Ticket ticketIn){
            var ticket = _ticketService.Get(id);

            if(ticket == null){
                return NotFound();
            }

            _ticketService.Update(id, ticketIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id){
            var ticket = _ticketService.Get(id);

            if(ticket == null){
                return NotFound();
            }

            _ticketService.Remove(ticket.id);

            return NoContent();
        }
    }
}