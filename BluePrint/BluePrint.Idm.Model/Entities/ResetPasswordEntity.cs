using BluePrint.Model.Entities.Concretes;

namespace BluePrint.Idm.Model.Entities
{
    public class ResetPasswordEntity : BaseEntity
    {
        public virtual string EMailAddress { get; set; }

        public virtual string Token { get; set; }

        public virtual string Password { get; set; }

        public virtual string PasswordRetype { get; set; }

        public virtual bool SendSuccessfulMail { get; set; }

        public virtual string SenderAccount { get; set; }

        public virtual string TemplateIdentifier { get; set; }

        public virtual string Subject { get; set; }
    }
}
