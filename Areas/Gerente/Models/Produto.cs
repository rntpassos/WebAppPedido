using System.ComponentModel.DataAnnotations;

namespace WebAppPedido.Areas.Gerente.Models;

public class Produto
{
    public Produto()
    {
    }

    public Produto(string descricao, decimal valor, int quantidade, string usuarioLogado)
    {
        Descricao = descricao;
        Valor = valor;
        Quantidade = quantidade;
        UsuarioCriacao = usuarioLogado;
        DataCriacao = DateTime.Now;
        RegistroAtivo = true;
    }

    public int ProdutoId { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public string? UsuarioAlteracao { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public string? UsuarioCriacao { get; set; }
    public DateTime? DataCriacao { get; set; }
    public bool RegistroAtivo { get; set; }
}
