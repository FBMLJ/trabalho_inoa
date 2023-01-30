

using System.ComponentModel.DataAnnotations;

namespace MvcMoeda.Models;

public class Moeda
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }

}
