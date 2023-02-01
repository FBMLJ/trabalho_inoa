
using System.ComponentModel.DataAnnotations.Schema;
using MvcMoeda.Models;

namespace MvcMonitoramento.Models;

public class Monitoramento
{
    public int Id { get; set; }
    public string Nome { get; set; }



    public int MoedaOrigemId { get; set; }
   

    public int MoedaAlvoId { get; set; }
    

    
    
   

    public float ValorDeVenda {get ; set;}

    public float ValorDeCompra {get; set;}

}
