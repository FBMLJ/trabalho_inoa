
using System.ComponentModel.DataAnnotations.Schema;
using MvcMoeda.Models;

namespace MvcMonitoramento.Models;

public class Monitoramento
{
    public int Id { get; set; }
    public string Nome { get; set; }



    public int MoedaId1 { get; set; }
    [ForeignKey("MoedaId1")]
    public Moeda Moeda1 { get; set;}

    public int MoedaId2 { get; set; }
    [ForeignKey("MoedaId2")]
    public Moeda Moeda2 { get; set;}

    
    
   

    public float ValorDeVenda {get ; set;}

    public float ValorDeCompra {get; set;}

}
