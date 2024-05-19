using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Utils.Mail
{
    public interface IMailService
    {

        void SendEmail(MailRequest mailRequest);
        Task SendEmailAsync(MailRequest request);
    }
}
