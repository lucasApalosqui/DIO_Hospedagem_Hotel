using DioHospedagemHotel.Domain.ValueObjects;

namespace DioHospedagemHotel.Domain.Entities
{
    public class HospResponsavel : Hospede
    {
        public HospResponsavel(string name, string lastName, Rg rg, Cpf cpf, Email email, Phone phone)
        {
            Name = name;
            LastName = lastName;
            Rg = rg;
            Cpf = cpf;
            Email = email;
            Phone = phone;
        }

        public Phone Phone { get; set; }
        public Email Email { get; set; }
        public Cpf Cpf { get; set; }

    }
}
