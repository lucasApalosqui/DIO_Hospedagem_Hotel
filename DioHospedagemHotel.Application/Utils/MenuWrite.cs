namespace DioHospedagemHotel.Application.Utils
{
    public static class MenuWrite
    {
        public static void OptionGen(List<string> options)
        {
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            var num = 0;
            foreach (string option in options)
            {
                num++;
                Console.WriteLine($"{num} - {option}");
            }
        }
    }
}
