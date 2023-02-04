using System.Net;
using System.Net.Mail;
using Quartz;
using MvcMoeda.Models;
using MvcMonitoramento.Models;

using Newtonsoft.Json.Linq;

public class SendEmailJob : IJob
{
    ApplicationDbContext _context;
    private static readonly HttpClient client = new HttpClient();

    public SmtpClient smtpClient;
    public String emailFrom = "lucastavateste@gmail.com";
    public SendEmailJob( ApplicationDbContext context){
        _context = context; 
        smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("lucastavateste@gmail.com", "bvzqtaelhifjscpn"),
            EnableSsl = true,
        };
    }
    public async Task Execute(IJobExecutionContext context)
    {
        // Console.WriteLine("TESTE ");
        
         var moedas = (IEnumerable<Moeda>)  _context.Moeda.ToList();
        var monitoramentos = (IEnumerable<Monitoramento>)  _context.Monitoramento.ToList();

        foreach (var monitoramento in monitoramentos){

            var moedaOrigem = moedas.First(x => x.Id == monitoramento.MoedaOrigemId).Nome;
            var moedaAlvo = moedas.First(x => x.Id == monitoramento.MoedaAlvoId).Nome;
            var response = await client.GetAsync("https://economia.awesomeapi.com.br/last/"+moedaOrigem+"-"+moedaAlvo+"");

            var responseString = await response.Content.ReadAsStringAsync();
            JObject json_response = JObject.Parse(responseString);
            String temp = (string)json_response[moedaOrigem+moedaAlvo]["bid"];
            
            temp = temp.Replace(".", ",");
            
            var valorAtual = float.Parse(temp);
            Console.WriteLine(valorAtual);
            Console.WriteLine(monitoramento.ValorDeCompra);
            Console.WriteLine(monitoramento.ValorDeVenda);
            if (monitoramento.ValorDeCompra > valorAtual){
                Console.WriteLine("Enviando Email");

                 smtpClient.Send(emailFrom, monitoramento.Nome, "Aconselhamento sobre a compra do ativo", $@"
                Conforme o valor de compra de referencia inserido no sistema e o valor da contação {moedaOrigem} para {moedaAlvo}, é recomendado efetuar a compra do ativo.
                A motivação disso é que o valor de venda atual, {monitoramento.ValorDeCompra}, ser maior que o {valorAtual}.
                Atenciosamente,
                Projeto Teste
                Envio automático. Favor não responder este e-mail. 
            ");

            }

            if (monitoramento.ValorDeCompra < valorAtual){
                Console.WriteLine("Enviando Email");

                smtpClient.Send(emailFrom, monitoramento.Nome,"Aconselhamento sobre a venda do ativo ", $@"
                Conforme o valor de venda de referencia inserido no sistema e o valor da contação {moedaOrigem} para {moedaAlvo}, é recomendado efetuar a venda do ativo.
                A motivação disso é que que o valor de venda atual, {monitoramento.ValorDeCompra}, ser menor que o {valorAtual}.
                Atenciosamente,
                Projeto Teste
                Envio automático. Favor não responder este e-mail. 
                ");

            }

            

        }

        return;
    }
}   