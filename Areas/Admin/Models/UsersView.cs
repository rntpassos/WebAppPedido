namespace WebAppPedido.Areas.Admin.Models;

public record UsersView2(string Id, string Nome, string email, List<UserRoles> Roles);

public record UserRoles(string Id, string RoleName);