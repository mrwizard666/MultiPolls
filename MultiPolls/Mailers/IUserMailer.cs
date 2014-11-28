using Mvc.Mailer;

namespace MultiPolls.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Welcome();
			MvcMailMessage PasswordReset();
	}
}