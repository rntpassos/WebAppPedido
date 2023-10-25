namespace WebAppPedido.Services;

public interface ISeedUserRole
{
    Task SeedRolesAsync();
    Task SeedUsersAsync();
}
