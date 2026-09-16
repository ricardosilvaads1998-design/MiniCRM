using System.Collections.Generic;

namespace MiniCRM.Models
{
    public class DashboardViewModel
    {
        public int TotalClientes { get; set; }

        public List<Cliente> UltimosClientes { get; set; } = new List<Cliente>();
    }
}