using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agencia_De_Turismo_App.Pages.DescontoPage
{
    public delegate decimal CalculateDelegate(decimal precoOriginal);
    public class IndexModel : PageModel
    {
        [BindProperty]
        public decimal PrecoOriginal { get; set; }

        public decimal PrecoComDesconto { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            CalculateDelegate aplicarDesconto = preco => preco * 0.9m;

            PrecoComDesconto = aplicarDesconto(PrecoOriginal);
        }
    }
}
