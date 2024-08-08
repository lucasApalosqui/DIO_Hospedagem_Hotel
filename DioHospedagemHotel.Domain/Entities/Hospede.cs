using DioHospedagemHotel.Domain.ValueObjects;
using System.Reflection.Metadata;

namespace DioHospedagemHotel.Domain.Entities
{
    public abstract class Hospede
    {
        public Guid NumIdentity { get; } = Guid.NewGuid();
        public Rg Rg { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
