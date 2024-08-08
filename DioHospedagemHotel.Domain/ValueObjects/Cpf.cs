using DioHospedagemHotel.Domain.Utils.ResponseUtils;
using System.Text.RegularExpressions;

namespace DioHospedagemHotel.Domain.ValueObjects
{
    public class Cpf
    {

        public Cpf(string cpfAddress)
        {
            CpfAddress = cpfAddress;
        }

        public string CpfAddress { get; set; }

        public GenericResponse IsValid()
        {
            GenericResponse response = new GenericResponse();

            if (CpfAddress.Length != 11)
                response.AddMessage("Cpf deve conter 11 caracteres");

            if(long.TryParse(CpfAddress, out var result) == false)
                response.AddMessage("Cpf deve conter apenas números");

            response.Validate();

            return response;
        }

        public string Mask()
        {
            return long.Parse(CpfAddress).ToString(@"000\.000\.000\-00");
        }
    }
}
