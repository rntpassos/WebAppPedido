using Microsoft.AspNetCore.Identity;

namespace WebAppPedido.Services;

public class SeedUserRole : ISeedUserRole
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedUserRole(UserManager<IdentityUser> userManager, 
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedRolesAsync()
    {
        if (! await _roleManager.RoleExistsAsync("User"))
        {
            IdentityRole role = new IdentityRole();
            role.Name = "User";
            role.NormalizedName = "USER";
            role.ConcurrencyStamp = Guid.NewGuid().ToString();

            IdentityResult roleResult = await _roleManager.CreateAsync(role);
        }
        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Admin";
            role.NormalizedName = "ADMIN";
            role.ConcurrencyStamp = Guid.NewGuid().ToString();

            IdentityResult roleResult = await _roleManager.CreateAsync(role);
        }
        if (!await _roleManager.RoleExistsAsync("Gerente"))
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Gerente";
            role.NormalizedName = "GERENTE";
            role.ConcurrencyStamp = Guid.NewGuid().ToString();

            IdentityResult roleResult = await _roleManager.CreateAsync(role);
        }
    }

    public async Task SeedUsersAsync()
    {
        if (await _userManager.FindByEmailAsync("admin@localhost") == null) {
            IdentityUser user = new IdentityUser();
            user.UserName = "admin@localhost";
            user.Email = "admin@localhost";
            user.NormalizedEmail = "ADMIN@LOCALHOST";
            user.NormalizedUserName = "ADMIN@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await _userManager.CreateAsync(user, "#123Mudar");

            if (result.Succeeded) {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

        }
    }
}
