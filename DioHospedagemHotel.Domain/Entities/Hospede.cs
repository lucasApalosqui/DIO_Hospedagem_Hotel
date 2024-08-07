using System.Reflection.Metadata;

namespace DioHospedagemHotel.Domain.Entities
{
    public abstract class Hospede
    {
        public Guid NumIdentity { get; } = new Guid();
        public string Rg { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
