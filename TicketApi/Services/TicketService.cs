using TicketApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TicketApi.Services{
    public class TicketService{

        private readonly IMongoCollection<Ticket> _tickets;

        public TicketService(ITicketDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tickets = database.GetCollection<Ticket>(settings.TicketCollectionName);
        }

        public List<Ticket> Get() =>
            _tickets.Find(ticket => true).ToList();

        public Ticket Get(string id) =>
            _tickets.Find<Ticket>(ticket => ticket.id == id).FirstOrDefault();

        public Ticket Create(Ticket ticket){
            _tickets.InsertOne(ticket);
            return ticket;
        }

        public void Update(string id, Ticket ticketIn){
            _tickets.ReplaceOne(ticket => ticket.id == id, ticketIn);
        }

        public void Remove(Ticket ticketIn){
            _tickets.DeleteOne(ticket => ticket.id == ticketIn.id);
        }

        public void Remove(string id){
            _tickets.DeleteOne(ticket => ticket.id == id);
        }
    }
}