namespace DioHospedagemHotel.Domain.ResponseUtils
{
    public class GenericResponse
    {
        public GenericResponse()
        {

        }

        public List<string> Message { get; private set; }
        public bool IsValid { get; private set; }

        public void Validate()
        {
            if (Message.Count != 0)
            {
                IsValid = false;
            }
                
        }

        public void AddMessage(string message)
        {
            Message.Add(message);
        }
    }
}
