
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MvcMoeda.Models;

namespace MvcMonitoramento.Models;

public class Monitoramento
{
    public int Id { get; set; }
    public string Nome { get; set; }



    public int MoedaOrigemId { get; set; }
   

    public int MoedaAlvoId { get; set; }
    

    
    
   
    [DisplayName("Limite do Valor de Venda")]
    public double  ValorDeVenda {get ; set;}

    [DisplayName("Limite do Valor de Compra")]
    public double  ValorDeCompra {get; set;}

}
