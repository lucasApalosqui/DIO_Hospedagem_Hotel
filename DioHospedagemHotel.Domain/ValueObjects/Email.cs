using DioHospedagemHotel.Domain.ResponseUtils;
using System.Text.RegularExpressions;

namespace DioHospedagemHotel.Domain.ValueObjects
{
    public class Email
    {
        public string EmailAddress { get; set; }

        public GenericResponse IsValid()
        {
            GenericResponse response = new GenericResponse();

            if (string.IsNullOrWhiteSpace(EmailAddress))
                response.AddMessage("Email não pode estar vazio");

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(EmailAddress, pattern))
                response.AddMessage("Email inválido");

            response.Validate();

            return response;
        }
    }
}
