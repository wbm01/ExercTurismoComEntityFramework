namespace Turismo_EntityF.Models
{
    public class Package
    {
        public int Id { get; set; }
        public Hotel HotelPackage { get; set; }
        public Ticket TicketPackage { get; set; }
        public DateTime DtRegisterPackage { get; set; }
        public double ValuePackage { get; set; }

        public Client ClientPackage { get; set; }
    }
}
