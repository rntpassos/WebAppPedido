using System.ComponentModel.DataAnnotations;

namespace WebAppPedido.Areas.Cliente.Models;

public class Cliente
{
    public int ClienteId { get; set; }
    public string? Nome { get; set; }
    [Display(Name = "Cpf / Cnpj")]
    public string? CpfCnpj { get; set; }
    public ICollection<EnderecoCliente>? Enderecos { get; set; }
}
