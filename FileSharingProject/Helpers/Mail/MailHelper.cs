using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace FileSharingProject.Helpers.Mail
{
    public class MailHelper : IMailHelper
    {
        private readonly IConfiguration _config;

        public MailHelper(IConfiguration config)
        {
            this._config = config;
        }
        public void SendMail(InputEmailMessage model)
        {
            try
            {
                using (SmtpClient client = new SmtpClient(_config.GetValue<string>("Mail:Host"), _config.GetValue<int>("Mail:Port")))
                {

                    var msg = new MailMessage();
                    msg.To.Add(model.Email);
                    msg.Subject = model.Subject;
                    msg.Body = model.Body;
                    msg.From = new MailAddress(_config.GetValue<string>("Mail:From"), _config.GetValue<string>("Mail:Sender"), System.Text.Encoding.UTF8);
                    msg.IsBodyHtml = true;
                    client.Credentials = new System.Net.NetworkCredential(_config.GetValue<string>("Mail:From"), _config.GetValue<string>("Mail:PWD"));


                    client.Send(msg);
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }
    }
}
