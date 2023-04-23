namespace Turismo_EntityF.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public string NameHotel { get; set; }

        public Address AddressHotel { get; set; }

        public DateTime DtRegisterHotel { get; set; }

        public decimal ValueHotel { get; set; }
    }
}
