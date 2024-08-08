using DioHospedagemHotel.Domain.Entities;

namespace DioHospedagemHotel.Domain.Utils.FilesUtils
{
    public static class WriteReserveData
    {
        public static string[] WriteReserve(HospResponsavel hospRes, List<Hospede> hospedeList, Suite suite, Reserva reserva)
        {
            string[] lines =
            {
                $"Dados da Reserva \n",
                $"Hospede Responsável: {hospRes.Name} {hospRes.LastName} RG: {hospRes.Rg.Mask()} CPF: {hospRes.Cpf.Mask()} Email: {hospRes.Email.EmailAddress} telefone: {hospRes.Phone.PhoneAddress}",
                $"Hospedes Convidados"

            };
            foreach (var hospede in hospedeList.OfType<HospConvidado>().ToList())
            {
                lines.Append($"Nome Completo: {hospede.Name} {hospede.LastName} RG: {hospede.Rg}");
            }

            lines.Append($"Cód Suite: {suite.Id} - Tipo: {suite.Tipo.ToString()} - Capacidade Máxima: {suite.Capacidade} - Valor Diária: {suite.ValorDiaria.ToString("C")} - Dias Reservados: {reserva.DiasReservados} - Valor Total: {reserva.CalcularValorTotal().ToString("C")}");

            return lines;
        }
    }
}
