namespace DioHospedagemHotel.Domain.Utils.ResponseUtils
{
    public class GenericResponse
    {
        public GenericResponse()
        {
            IsValid = true;
        }

        public List<string> Message { get; private set; } = new List<string>();
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
