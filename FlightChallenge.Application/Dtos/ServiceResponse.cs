namespace FlightChallenge.Application.Dtos
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; } = true;
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
