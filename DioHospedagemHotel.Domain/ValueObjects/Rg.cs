using DioHospedagemHotel.Domain.ResponseUtils;

namespace DioHospedagemHotel.Domain.ValueObjects
{
    public class Rg
    {
        public string RgAddress { get; set; }

        public GenericResponse IsValid()
        {
            GenericResponse response = new GenericResponse();

            if(RgAddress.Length != 9)
                response.AddMessage("RG deve conter 9 caracteres");

            if(!int.TryParse(RgAddress, out var result))
                response.AddMessage("Apenas números são permitidos no campo");

            response.Validate();

            return response;
        }
    }
}
