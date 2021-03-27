namespace TicketApi.Models{

    public class TicketDatabaseSettings : ITicketDatabaseSettings{
        public string TicketCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITicketDatabaseSettings{
        string TicketCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}