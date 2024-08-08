namespace DioHospedagemHotel.Application.Utils
{
    public static class ResponseManipulate
    {
        public static void SeeErrors(List<string> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
        }
    }
}
