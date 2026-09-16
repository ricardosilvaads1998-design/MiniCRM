using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniCRM.Data;
using MiniCRM.Models;

namespace MiniCRM.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clientes = _context.Clientes
                .OrderByDescending(c => c.Id)
                .ToList();

            var model = new DashboardViewModel
            {
                TotalClientes = clientes.Count,
                UltimosClientes = clientes.Take(5).ToList()
            };

            return View(model);
        }
    }
}