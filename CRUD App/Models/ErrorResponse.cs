namespace CRUD_App.Models
{
    public class ErrorResponse
    {
        public string ErrorCode { get; set; } = string.Empty;
        public string ErrorDescription { get; set; } = string.Empty;
        public DateTime ErrorGeneratedAt { get; set; }
    }
}
