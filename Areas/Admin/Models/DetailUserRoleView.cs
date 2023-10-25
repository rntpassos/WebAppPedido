namespace WebAppPedido.Areas.Admin.Models;

public class DetailUserRoleView
{
    public DetailUserRoleView()
    {
    }

    public string IdUsuario { get; set; }
    public string NomeUsuario { get; set; }
    public List<string> roles { get; set; }
    public List<string> naoRoles { get; set; }
    public string? Role { get; set; }
}
