using MailKit;
using WebApi.Models.Email;

namespace WebApi.Services;

using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using WebApi.Helpers;

public interface IEmailService
{
    void Send(string to, string subject, string html, string from = null);
    void SendOfQq(EmailRequest model);
}

internal class EmailService : IEmailService
{
    private readonly AppSettings _appSettings;

    public EmailService(IOptionsMonitor<AppSettings> appSettings)
    {
        _appSettings = appSettings.CurrentValue;
    }

    public void Send(string to, string subject, string html, string from = null)
    {
        // create message
        var email = new MimeMessage();
        // email.Sender = new MailboxAddress("带带带滴滴滴", from ?? _appSettings.EmailFrom);
        email.From.Add(new MailboxAddress("失心疯", from ?? _appSettings.EmailFrom));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) {Text = html};
        

        // send email
        using var smtp = new SmtpClient();
        smtp.Connect(_appSettings.SmtpHost, _appSettings.SmtpPort, SecureSocketOptions.StartTls);
        smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
        smtp.Send(email);
        smtp.Disconnect(true);
    }

    public void SendOfQq(EmailRequest model)
    {
        // create message
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress(model.FromName,  _appSettings.EmailFrom));
        email.To.Add(MailboxAddress.Parse(model.Email));
        email.Subject = model.Sub;
        email.Body = new TextPart(TextFormat.Html) {Text = _appSettings.HtmlForEmail};
        

        // send email
        using var smtp = new SmtpClient();
        smtp.Connect(_appSettings.SmtpHost, _appSettings.SmtpPort, SecureSocketOptions.StartTls);
        smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}