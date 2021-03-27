using TicketApi.Models;
using TicketApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TicketApi.Controllers{

    [Route ("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase{
        private readonly TicketService _ticketService;

        public TicketsController(TicketService ticketService){
            _ticketService = ticketService;
        }

        [HttpGet]
        public ActionResult<List<Ticket>> Get() =>
            _ticketService.Get();

        
    }
}