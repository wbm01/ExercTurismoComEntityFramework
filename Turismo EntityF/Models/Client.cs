namespace Turismo_EntityF.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string NameClient { get; set; }

        public string Phone { get; set; }

        public Address AddressClient { get; set; }

        public DateTime DtRegisterClient { get; set; }
    }
}
