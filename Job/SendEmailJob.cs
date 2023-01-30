using System.Net;
using System.Net.Mail;
using Quartz;

public class SendEmailJob : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine("TESTE ");
        return Task.FromResult(true);
        string to = "lucastavasousa@gmail.com";
        string from = "lucastavateste@gmail.com";
        MailMessage message = new MailMessage(from, to);
        message.Subject = "Recomendação da Inoa: Vender";
        message.Body = @"<p>O valor da contação da moeda X para moeda Y está acima do valor de venda configurado. Nós recomendamos vendê-la o mais breve possível<p>
        Atenciosamente, Inoa";
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(from, "bvzqtaelhifjscpn"),
            EnableSsl = true,
        };
        smtpClient.Send(from, to, message.Subject, message.Body);
        return Task.FromResult(true);
    }
}   