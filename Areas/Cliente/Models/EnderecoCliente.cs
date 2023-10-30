namespace WebAppPedido.Areas.Cliente.Models;

public class EnderecoCliente
{
    public int EnderecoClienteID { get; set; }
    public required string Denominacao { get; set; }
    public required string Logradouro { get; set; }
    public int Número { get; set; }
    public string? Complemento { get; set;}
    public bool Principal { get; set; }

    public int ClienteId { get; set; }
    public required Cliente Cliente { get; set; }
}
