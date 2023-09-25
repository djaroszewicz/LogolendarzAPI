namespace LogolendarzAPI.Models.Dto
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSucces { get; set; } = true;
        public string Messaege { get; set; } = "";
    }
}
