
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MvcMoeda.Models;

namespace MvcMonitoramento.Models;

public class Monitoramento
{
    public int Id { get; set; }
     [DisplayName("Endereço de email para envio")]
    public string Nome { get; set; }


     [DisplayName("Moeda de Origem")]
    public int MoedaOrigemId { get; set; }
   

    [DisplayName("Moeda de Destino")]
    public int MoedaAlvoId { get; set; }
    

    
    
   
    [DisplayName("Limite do Valor de Venda")]
    public double  ValorDeVenda {get ; set;}

    [DisplayName("Limite do Valor de Compra")]
    public double  ValorDeCompra {get; set;}

}
