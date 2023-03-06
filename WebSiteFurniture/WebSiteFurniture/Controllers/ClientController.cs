using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSiteFurniture.Entities;
using WebSiteFurniture.Models.Client;

namespace WebSiteFurniture.Controllers
{
    public class ClientController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        public ClientController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        // GET: ClientController
        public async Task<IActionResult> Index()
        {
            var allUsers = this.userManager.Users
            .Select(u => new ClientIndexVM
            {
                Id = u.Id,
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Address = u.Address,
                Email = u.Email,
            })
            .ToList();

            // Id на всички админи
            var adminIds = (await this.userManager.GetUsersInRoleAsync("Administrator"))
                .Select(a => a.Id).ToList();

            // Ако потребителят е в списъка, то IsAdmin става true
            foreach (var user in allUsers)
            {
                user.IsAdmin = adminIds.Contains(user.Id);
            }

            // Вадим само клиентите без админ и ги сортираме по username
            var users = allUsers.Where(x => x.IsAdmin == false)
                .OrderBy(x => x.UserName).ToList();
           
            //връщаме списък
            return this.View(users);
        }
    }
}
