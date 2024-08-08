using DioHospedagemHotel.Domain.Enums;

namespace DioHospedagemHotel.Domain.Entities
{
    public class Suite
    {
        public Suite(TipoSuite suite, int capacidade, double valorDiaria)
        {
            Tipo = suite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public Guid Id { get; set; } = new Guid();
        public TipoSuite Tipo {  get; private set; }
        public int Capacidade { get; private set; }
        public double ValorDiaria {  get; private set; }


    }
}
