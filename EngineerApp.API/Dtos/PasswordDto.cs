namespace EngineerApp.API.Dtos
{
    public class PasswordDto
    {
        public int IdUser { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}