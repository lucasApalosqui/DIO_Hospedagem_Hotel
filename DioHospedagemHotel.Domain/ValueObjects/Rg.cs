using DioHospedagemHotel.Domain.Utils.ResponseUtils;

namespace DioHospedagemHotel.Domain.ValueObjects
{
    public class Rg
    {
        public Rg(string rgAddress)
        {
            RgAddress = rgAddress;
        }

        public string RgAddress { get; set; }

        public GenericResponse IsValid()
        {
            GenericResponse response = new GenericResponse();

            if(RgAddress.Length != 9)
                response.AddMessage("RG deve conter 9 caracteres");

            if(!long.TryParse(RgAddress, out var result))
                response.AddMessage("Apenas números são permitidos no campo");

            response.Validate();

            return response;
        }

        public string Mask()
        {
            return RgAddress.Substring(0, 2) + "." + RgAddress.Substring(2, 3) + "." + RgAddress.Substring(5, 3) + "-" + RgAddress.Substring(8, 1).ToUpper();
        }
    }
}
