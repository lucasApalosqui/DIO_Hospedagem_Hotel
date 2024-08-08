using DioHospedagemHotel.Domain.Entities;
using System.Linq;

namespace DioHospedagemHotel.Domain.Utils.FilesUtils
{
    public static class WriteReserveData
    {
        public static List<string> WriteReserve(HospResponsavel hospRes, List<Hospede> hospedeList, Suite suite, Reserva reserva)
        {
            List<string> lines = new List<string>();
            lines.Add("Dados da Reserva");

            lines.Add($"Hospede Responsável: {hospRes.Name} {hospRes.LastName} RG: {hospRes.Rg.Mask()} CPF: {hospRes.Cpf.Mask()} Email: {hospRes.Email.EmailAddress} telefone: {hospRes.Phone.PhoneAddress}");
            lines.Add($"Hospedes Convidados");


            foreach (var hospede in hospedeList.OfType<HospConvidado>().ToList())
            {
                lines.Add($"Nome Completo: {hospede.Name} {hospede.LastName} RG: {hospede.Rg.Mask()}");
            }

            lines.Add($"Cód Suite: {suite.Id} - Tipo: {suite.Tipo.ToString()} - Capacidade Máxima: {suite.Capacidade} - Valor Diária: {suite.ValorDiaria.ToString("C")} - Dias Reservados: {reserva.DiasReservados} - Valor Total: {reserva.CalcularValorTotal().ToString("C")}");

            return lines;
        }
    }
}
