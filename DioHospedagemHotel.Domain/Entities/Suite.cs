using DioHospedagemHotel.Domain.Enums;

namespace DioHospedagemHotel.Domain.Entities
{
    public class Suite
    {
        public Suite(TipoSuite suite, int capacidade, double valorDiaria)
        {
            Id = Guid.NewGuid();
            Tipo = suite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public Guid Id { get; set; }
        public TipoSuite Tipo {  get; private set; }
        public int Capacidade { get; private set; }
        public double ValorDiaria {  get; private set; }


    }
}
