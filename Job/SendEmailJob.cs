using System.Net;
using System.Net.Mail;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMoeda.Models;
using MvcMonitoramento.Models;

public class SendEmailJob : IJob
{
    ApplicationDbContext _context;


    public SendEmailJob( ApplicationDbContext context){
        _context = context; 
    }
    public Task Execute(IJobExecutionContext context)
    {
        // Console.WriteLine("TESTE ");
         var moedas = (IEnumerable<Moeda>)  _context.Moeda.ToList();
        var monitoramentos = (IEnumerable<Monitoramento>)  _context.Monitoramento.ToList();
        foreach (var monitoramento in monitoramentos){

            Console.WriteLine(moeda.First(x => x.Id == monitoramento.MoedaOrigemId));

        }

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