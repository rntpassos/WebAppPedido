using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppPedido.Areas.Admin.Models;

namespace WebAppPedido.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EditUsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EditUsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: EditUsersController
        public async Task<ActionResult> Index()
        {
            var usuarios = await _userManager.Users.ToListAsync();
            List<UsersView> model = new List<UsersView>();

            foreach (var user in usuarios)
            {
                var roles = await _userManager.GetRolesAsync(user);
                UsersView userModel = new UsersView(user.Id, user.Email, user.UserName, (List<string>)roles);
                model.Add(userModel);
            }
            return View(model);
        }

        // GET: EditUsersController/{id}
        public async Task<IActionResult> DetailUserRole(Guid? Id)
        {
            var usuario = await _userManager.FindByIdAsync(Id.ToString());
            if (usuario == null)
                return View();

            DetailUserRoleView view = await GetView(usuario);

            return View(view);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveRole(DetailUserRoleView model)
        {
            var usuario = await _userManager.FindByIdAsync(model.IdUsuario);
            var role = await _roleManager.FindByNameAsync(model.Role);
            await _userManager.RemoveFromRoleAsync(usuario, role.Name);

            DetailUserRoleView view = await GetView(usuario);
            return View("DetailUserRole", view);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(DetailUserRoleView model)
        {
            var usuario = await _userManager.FindByIdAsync(model.IdUsuario);
            var role = await _roleManager.FindByNameAsync(model.Role);
            await _userManager.AddToRoleAsync(usuario, role.Name);

            DetailUserRoleView view = await GetView(usuario);
            return View("DetailUserRole", view);
        }

        private async Task<DetailUserRoleView> GetView(IdentityUser usuario) {
            DetailUserRoleView view = new DetailUserRoleView();
            var roles = await _roleManager.Roles.ToListAsync();
            var rolesUsuario = await _userManager.GetRolesAsync(usuario);
            view.IdUsuario = usuario.Id;
            view.NomeUsuario = usuario.UserName;
            view.roles = new List<string>();
            view.naoRoles = new List<string>();
            foreach (var role in roles)
            {
                if (rolesUsuario.Any(x => x.Equals(role.Name)))
                    view.roles.Add(role.Name);
                else
                    view.naoRoles.Add(role.Name);
            }
            return view;
        }
    }
}
