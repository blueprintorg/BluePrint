using BluePrint.Model.Dtos.Concretes;

namespace BluePrint.Idm.Model.Dtos
{
    public class ResetPasswordDto : BaseDto
    {
        public string EMailAddress { get; set; }

        public string Token { get; set; }
        
        public string Password { get; set; }
        
        public string PasswordRetype { get; set; }
        
        public bool SendSuccessfulMail { get; set; }
        
        public string SenderAccount { get; set; }
        
        public string TemplateIdentifier { get; set; }
        
        public string Subject { get; set; }
    }
}
