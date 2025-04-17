using System.Net;
using System.Net.Mail;

namespace ContactSystem.Helper;

class Email : IEmail
{
    private readonly IConfiguration _config;

    public Email(IConfiguration configuration) =>
        _config = configuration;

    public bool Send(string address, string subject, string message)
    {
        try
        {
            string username = _config.GetValue<string>("SMTP:UserName");
            string name = _config.GetValue<string>("SMTP:Name");
            string host = _config.GetValue<string>("SMTP:Host");
            string password = _config.GetValue<string>("SMTP:Password");
            int port = _config.GetValue<int>("SMTP:Port");

            MailMessage mail = new() { From = new(username, name) };

            mail.To.Add(address);
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            using SmtpClient smtp = new(host, port);
            smtp.Credentials = new NetworkCredential(username, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return true;
        }
        catch (Exception error)
        {
            return false;
        }
    }
}