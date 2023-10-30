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
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    [Display(Name = "Usuário de Alteração")]
    public string? UsuarioAlteracao { get; set; }
    [Display(Name = "Data de Alteração")]
    public DateTime? DataAlteracao { get; set; }
    [Display(Name = "Usuário de Criação")]
    public string? UsuarioCriacao { get; set; }
    [Display(Name = "Data de Criação")]
    public DateTime? DataCriacao { get; set; }
    [Display(Name = "Ativo")]
    public bool RegistroAtivo { get; set; }
}
