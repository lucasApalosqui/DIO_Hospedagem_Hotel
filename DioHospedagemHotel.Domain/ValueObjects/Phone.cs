using DioHospedagemHotel.Domain.ResponseUtils;

namespace DioHospedagemHotel.Domain.ValueObjects
{
    public class Phone
    {
        public Phone(string phone)
        {
            PhoneAddress = phone;
        }

        public string PhoneAddress { get; set; }
        

        public GenericResponse IsValid()
        {
            GenericResponse response = new GenericResponse();

            if (PhoneAddress.Length != 11)
                response.AddMessage("Telefone deve conter 11 caracteres!");

            if (int.TryParse(PhoneAddress, out var result) == false)
                response.AddMessage("Apenas numeros são permitidos no campo!");

            response.Validate();

            return response;
        }
    }
}
