using DioHospedagemHotel.Domain.Utils.FilesUtils;
using DioHospedagemHotel.Domain.Utils.ResponseUtils;

namespace DioHospedagemHotel.Domain.Entities
{
    public class Reserva
    {
        private readonly HospResponsavel _hospRes;
        public Reserva(Suite suite, HospResponsavel hospRes, int diasReservados)
        {
            Suite = suite;
            HospedeList.Add(hospRes);
            DiasReservados = diasReservados;
            _hospRes = hospRes;
        }

        public Suite Suite { get; private set; }
        public List<Hospede> HospedeList { get; private set; } = new List<Hospede>();
        public int DiasReservados { get; private set; }

        public GenericResponse CadastrarHospedes(List<Hospede> hospConv)
        {
            GenericResponse response = new GenericResponse();
            if (hospConv.Count + 1 > Suite.Capacidade)
                response.AddMessage("Quantidade de hospedes não pode ultrapassar a capacidade da suite");

            response.Validate();

            if (response.IsValid)
            {
                foreach (var hosp in hospConv)
                {
                    HospedeList.Add(hosp);
                }
            }

            return response;
        }

        public int ObterQuantidadeHospedes()
        {
            return HospedeList.Count;
        }

        public double CalcularValorTotal()
        {
            return Suite.ValorDiaria * DiasReservados;
        }

        public GenericResponse GerarArquivoComDadosDaReserva(string pathFile)
        {
            GenericResponse resp = new GenericResponse();
            string[] linesToAdd = WriteReserveData.WriteReserve(_hospRes, HospedeList, Suite, this);
            try
            {
                File.WriteAllLines(pathFile, linesToAdd);
                resp.Validate();
                return resp;
            }
            catch (Exception ex)
            {
                {
                    resp.AddMessage("Erro ao gerar arquivo");
                    resp.Validate();
                    return resp;
                }
            }
        }
    }
}
