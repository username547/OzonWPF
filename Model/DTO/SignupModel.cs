namespace Ozon.Model.DTO
{
    public class SignupModel
    {
        public string UserName { get; set; } = string.Empty;
        public string UserSurname { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string UserPasswordConfirm { get; set; } = string.Empty;
    }
}
