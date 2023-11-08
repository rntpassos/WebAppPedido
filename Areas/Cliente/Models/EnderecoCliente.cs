using System.ComponentModel.DataAnnotations;

namespace WebAppPedido.Areas.Cliente.Models;

public class EnderecoCliente
{
    public int EnderecoClienteID { get; set; }
    [Display(Name = "Denominação")]
    public required string Denominacao { get; set; }
    [Display(Name = "Logradouro")]
    public required string Logradouro { get; set; }
    [Display(Name = "Numero")]
    public int Numero { get; set; }
    public string? Complemento { get; set;}
    public bool Principal { get; set; }
    public int ClienteId { get; set; }
    public required Cliente Cliente { get; set; }
}
