using System;
using System.Net.Mail;
using HRMS.BUSINESS.Interfaces;

namespace HRMS.BUSINESS.Services;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;

    public EmailService(SmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var mailMessage = new MailMessage("your-email@example.com", toEmail, subject, body);
        await _smtpClient.SendMailAsync(mailMessage);
    }
}
