using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agencia_De_Turismo_App.Pages.CalculoPage
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int NumeroDiarias { get; set; }

        [BindProperty]
        public decimal ValorDiaria { get; set; }

        public decimal? ValorTotal { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            Func<int, decimal, decimal> calcularTotal = (diarias, valor) => diarias * valor;

            ValorTotal = calcularTotal(NumeroDiarias, ValorDiaria);
        }
    }
}
