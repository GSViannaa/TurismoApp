using Agencia_De_Turismo_App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TurismoApp.Domain.models;

namespace Agencia_De_Turismo_App.Pages.CadastroCidadePage
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public CidadeDestino Cidade { get; set; } = new();

        public SelectList ListaPaises { get; set; } = null!;

        public void OnGet()
        {
            ListaPaises = new SelectList(_context.PaisesDestino.ToList(), "Id", "Nome");
        }
        public IActionResult OnPost()
        {
            ListaPaises = new SelectList(_context.PaisesDestino.ToList(), "Id", "Nome");

            if (!ModelState.IsValid)
                return Page();

            _context.CidadesDestino.Add(Cidade);
            _context.SaveChanges();

            return RedirectToPage("/CadastroCidadePage"); 
        }
    }
}
