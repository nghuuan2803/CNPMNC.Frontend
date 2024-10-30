namespace AdminUI.Objects.Response
{
    public class LoginInfo
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string EmployeeId { get; set; }
    }
}
