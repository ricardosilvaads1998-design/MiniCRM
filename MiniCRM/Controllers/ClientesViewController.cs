using Microsoft.AspNetCore.Mvc;
using MiniCRM.Data;
using MiniCRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiniCRM.Controllers
{
    [Authorize]
    public class ClientesViewController : Controller
    {
        private readonly AppDbContext _context;

        public ClientesViewController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

           return View(cliente);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente =_context.Clientes.Find(id);
            if(cliente==null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            TempData["Sucesso"] = "Cliente apagado com sucesso!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            var clienteExistente = _context.Clientes.Find(cliente.Id);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Telefone = cliente.Telefone;
            _context.SaveChanges();
            TempData["Sucesso"] = "Cliente atualizado com sucesso!";
            return RedirectToAction("Index");
        }

       
        public IActionResult Index(string pesquisa, int pagina = 1)
        {
            const int clientesPorPagina = 10;

            var clientes = _context.Clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                clientes = clientes.Where(c =>
                    c.Nome.Contains(pesquisa) ||
                    c.Email.Contains(pesquisa));
            }

            var totalClientes = clientes.Count();

            var clientesPagina = clientes
                .Skip((pagina - 1) * clientesPorPagina)
                .Take(clientesPorPagina)
                .ToList();

            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling(
                (double)totalClientes / clientesPorPagina);

            ViewBag.Pesquisa = pesquisa;

            return View(clientesPagina);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            TempData["Sucesso"] = "Cliente criado com sucesso!";

            return RedirectToAction("Index");
        }
    }
}