namespace WebAppPedido.Areas.Admin.Models;

public class UsersView
{
    public UsersView()
    {
    }

    public UsersView(string id, string name, string email, IList<string> roles)
    {
        Id = id;
        Name = name;
        Email = email;
        Roles = roles;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public IList<string> Roles { get; set; }
}