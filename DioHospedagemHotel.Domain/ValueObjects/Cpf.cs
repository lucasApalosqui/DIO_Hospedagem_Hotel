using DioHospedagemHotel.Domain.ResponseUtils;
using System.Text.RegularExpressions;

namespace DioHospedagemHotel.Domain.ValueObjects
{
    public class Cpf
    {
        public string CpfAddress { get; set; }

        public GenericResponse IsValid()
        {
            GenericResponse response = new GenericResponse();

            if (CpfAddress.Length != 11)
                response.AddMessage("Cpf deve conter 11 caracteres");

            if (!int.TryParse(CpfAddress, out var result))
                response.AddMessage("Cpf deve conter apenas números");

            response.Validate();

            return response;
        }
    }
}
