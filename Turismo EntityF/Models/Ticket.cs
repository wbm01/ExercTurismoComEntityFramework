namespace Turismo_EntityF.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Address Origin { get; set; }

        public Address Destiny { get; set; }

        public Client ClientTicket { get; set; }

        public DateTime DateTicket { get; set; }

        public decimal ValueTicket { get; set; }
    }
}
